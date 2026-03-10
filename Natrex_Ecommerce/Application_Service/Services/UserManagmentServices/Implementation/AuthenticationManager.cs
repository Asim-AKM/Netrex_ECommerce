namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class AuthenticationManager : IAuthenticationManager
    {
        #region DEPENDENCY INJECTION
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncriptor _passwordEncriptor;
        private readonly IJwtManager _jwtManager;
        private readonly IEmailManager _emailManager;
        private readonly ILogger<AuthenticationManager> _logger;

        public AuthenticationManager(IUnitOfWork unitOfWork, IPasswordEncriptor passwordEncriptor, IJwtManager jwtManager, IEmailManager emailManager, ILogger<AuthenticationManager> logger)
        {
            _unitOfWork = unitOfWork;
            _passwordEncriptor = passwordEncriptor;
            _jwtManager = jwtManager;
            _emailManager = emailManager;
            _logger = logger;
        }
        #endregion

        #region Funtions
        public async Task<ApiResponse<CreateUserDto>> CreateUserAsync(CreateUserDto request)
        {
            _logger.LogInformation("Registration attempt for Email: {Email}", request.Email);

            // Validate UserIdentifier for Unique Entry
            var emailExistance = await _unitOfWork.UserRepo.GetUserByIdentifier(request.Email);
            var userNameExistance = await _unitOfWork.UserRepo.GetUserByIdentifier(request.UserName);

            //if email exist and is pending resend otp 
            if (emailExistance != null && emailExistance.Status == UserStatus.Pending)
            {
                _logger.LogWarning("Pending account found, resending OTP to Email: {Email}", request.Email);

                var userCread = await _unitOfWork.UserCreadRepo.GetCreadbyFK(emailExistance.UserId);

                var otpcheck = OtpExpiryCheck(userCread);
                if (otpcheck != null)
                {
                    return ApiResponse<CreateUserDto>.Fail(
                        otpcheck.Message,
                        otpcheck.Status
                    );
                }

                // Generate new OTP only if expired
                var otp = new Random().Next(100000, 999999).ToString();
                var otpExpiry = DateTime.UtcNow.AddMinutes(5);

                await _unitOfWork.UserCreadRepo.UpdateOtp(otp, otpExpiry, emailExistance.UserId);
                await _emailManager.SendRegistrationOtpEmail(emailExistance.Email, emailExistance.FullName, otp);

                return ApiResponse<CreateUserDto>.Success(
                    request,
                    "Account already exists but not verified. New OTP sent to your email.",
                    ResponseType.Ok
                );
            }

            // Acomulate Errors in a list 
            if (emailExistance != null || userNameExistance != null)
            {
                _logger.LogWarning("Registration failed - duplicate Email: {Email} or Username: {UserName}", request.Email, request.UserName);

                List<string> errorsList = new List<string>();
                if (emailExistance != null)
                    errorsList.Add("Email Already Exist");
                if (userNameExistance != null)
                    errorsList.Add("UserName Already Exist");

                var error = string.Join(" | ", errorsList);
                return ApiResponse<CreateUserDto>.Fail(error, ResponseType.Conflict);
            }

            var user = request.MapToDomain();
            var cread = user.AssignCreads(request.Password);

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    await _unitOfWork.UserRepo.Create(user);
                    await _unitOfWork.UserCreadRepo.Create(cread);
                    await _unitOfWork.UserRoleRepo.Create(user.AssingRole());
                    await _unitOfWork.CustomerRepo.Create(request.MapToCustomer(user.UserId));
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save user to database. Email: {Email}", request.Email);
                return ApiResponse<CreateUserDto>.Fail("Failed to Create User", ResponseType.BadRequest);
            }

            // Send OTP email using new email service
            var emailSent = await _emailManager.SendRegistrationOtpEmail(user.Email, user.FullName, cread.OTP);
            if (emailSent)
            {
                _logger.LogInformation("User registered successfully. OTP sent to Email: {Email}", user.Email);
                return ApiResponse<CreateUserDto>.Success(
                    request,
                    "User created successfully. Please verify your email with the OTP sent to your inbox.",
                    ResponseType.Created
                );
            }

            _logger.LogError("User created but email sending failed. Email: {Email}", user.Email);
            return ApiResponse<CreateUserDto>.Fail("User created but failed to send verification email. Please use resend OTP.", ResponseType.InternalServerError);
        }

        public async Task<ApiResponse<string>> VerifyRegistrationOtpAsync(VerifyRegistrationOtpDto request)
        {
            // Find user by email
            var user = await _unitOfWork.UserRepo.GetUserByIdentifier(request.Email);

            _logger.LogInformation("OTP verification attempt for Email: {Email}", request.Email);

            if (user == null)
            {
                _logger.LogWarning("OTP verification failed - user not found. Email: {Email}", request.Email);
                return ApiResponse<string>.Fail("User not found", ResponseType.NotFound);
            }

            // Check if already verified
            if (user.Status == UserStatus.Active)
                return ApiResponse<string>.Fail("Email already verified. You can login now.", ResponseType.BadRequest);

            // Get user credentials
            var userCread = await _unitOfWork.UserCreadRepo.GetCreadbyFK(user.UserId);

            if (userCread == null)
                return ApiResponse<string>.Fail("User credentials not found", ResponseType.NotFound);

            // Check OTP expiry
            if (userCread.OTPExpiry == null || userCread.OTPExpiry < DateTime.UtcNow)
                return ApiResponse<string>.Fail("OTP has expired. Please request a new one.", ResponseType.BadRequest);

            // Verify OTP
            if (userCread.OTP != request.Otp)
            {
                _logger.LogWarning("Invalid OTP entered for Email: {Email}", request.Email);
                return ApiResponse<string>.Fail("Invalid OTP. Please check and try again.", ResponseType.BadRequest);
            }

            // Update user status to Active
            user.Status = UserStatus.Active;
            user.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.UserRepo.Update(user);

            // Clear OTP
            await _unitOfWork.UserCreadRepo.UpdateOtp(string.Empty, null, user.UserId);

            // Save changes
            var saved = await _unitOfWork.SaveChangesAsync() > 0;

            if (saved)
            {
                _logger.LogInformation("Email verified successfully for Email: {Email}", user.Email);
                // send welcome email
                await _emailManager.SendWelcomeEmail(user.Email, user.FullName);

                return ApiResponse<string>.Success(null!, "Email verified successfully! You can now login.", ResponseType.Ok);
            }

            return ApiResponse<string>.Fail("Failed to verify email", ResponseType.InternalServerError);
        }

        public async Task<ApiResponse<string>> ResendRegistrationOtpAsync(string email)
        {
            _logger.LogInformation("Resend OTP request for Email: {Email}", email);
            // Find user by email
            var user = await _unitOfWork.UserRepo.GetUserByIdentifier(email);

            if (user == null)
                return ApiResponse<string>.Fail("User not found", ResponseType.NotFound);

            // Check if already verified
            if (user.Status == UserStatus.Active)
                return ApiResponse<string>.Fail("Email already verified. You can login now.", ResponseType.BadRequest);

            var userCread = await _unitOfWork.UserCreadRepo.GetCreadbyFK(user.UserId);
            var checkotp = OtpExpiryCheck(userCread);
            if (checkotp != null)
                return ApiResponse<string>.Fail(checkotp.Message);

            // Generate new OTP
            var otp = new Random().Next(100000, 999999).ToString();
            var otpExpiry = DateTime.UtcNow.AddMinutes(5);
            var otpUpdated = await _unitOfWork.UserCreadRepo.UpdateOtp(otp, otpExpiry, user.UserId);

            if (otpUpdated > 0)
            {
                // Send OTP email
                var emailSent = await _emailManager.SendRegistrationOtpEmail(user.Email, user.FullName, otp);

                return emailSent
                    ? ApiResponse<string>.Success(null!, "OTP resent successfully. Please check your email.", ResponseType.Ok)
                    : ApiResponse<string>.Fail("Failed to send OTP email", ResponseType.InternalServerError);
            }

            return ApiResponse<string>.Fail("Failed to generate OTP", ResponseType.InternalServerError);
        }
        public async Task<ApiResponse<LoginResultDto>> LoginAsync(LoginDto request)
        {
            _logger.LogInformation("Login attempt for Identifier: {UserIdentifier}", request.UserIdentifier);

            var userExistance = await _unitOfWork.UserRepo.GetUserByIdentifier(request.UserIdentifier);

            if (userExistance == null)
            {
                _logger.LogWarning("Login failed - user not found. Identifier: {UserIdentifier}", request.UserIdentifier);
                return ApiResponse<LoginResultDto>.Fail("Invalid Creadentials", ResponseType.Unauthorized);
            }

            // Check if email is verified , IF pending resend otp
            if (userExistance.Status == UserStatus.Pending)
            {
                var userCreadcheck = await _unitOfWork.UserCreadRepo.GetCreadbyFK(userExistance.UserId);
                var otpcheck = OtpExpiryCheck(userCreadcheck);
                if (otpcheck != null) return ApiResponse<LoginResultDto>.Fail(otpcheck.Message);

                // Generate new OTP and send email
                var otp = new Random().Next(100000, 999999).ToString();
                var otpExpiry = DateTime.UtcNow.AddMinutes(5);
                await _unitOfWork.UserCreadRepo.UpdateOtp(otp, otpExpiry, userExistance.UserId);
                await _emailManager.SendRegistrationOtpEmail(userExistance.Email, userExistance.FullName, otp);

                return ApiResponse<LoginResultDto>.Fail(
                    "Please verify your email before logging in. New OTP sent to your inbox.",
                    ResponseType.Unauthorized
                );
            }

            // check creadentials
            var userCread = await _unitOfWork.UserCreadRepo.GetCreadbyFK(userExistance.UserId);
            if (userCread == null)
            {
                return ApiResponse<LoginResultDto>.Fail("User Creads Not Found", ResponseType.NotFound);
            }
            var isVerified = await _passwordEncriptor.VerifyPassword(request.Password, userCread.PasswordSalt, userCread.PasswordHash);

            if (!isVerified)
            {
                _logger.LogWarning("Login failed - invalid password. Identifier: {UserIdentifier}", request.UserIdentifier);
                return ApiResponse<LoginResultDto>.Fail("Invalid Creadentials", ResponseType.Unauthorized);
            }

            var userRole = await _unitOfWork.UserRoleRepo.GetUserRoles(userExistance.UserId);
            var customer = await _unitOfWork.CustomerRepo.FirstOrDefaultAsync(c => c.UserId == userExistance.UserId);
            var jwtToken = await _jwtManager.GenerateJwtToken(userExistance, userRole, customer!.ImageUrl ?? string.Empty);

            // Generate a secure random refresh token
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(randomBytes);


            // Store the refresh token in the database  
            var sessionAdded = await SaveSessions(new AddUserSessionDto(userExistance.UserId, refreshToken));


            if (!sessionAdded)
                return ApiResponse<LoginResultDto>.Fail("Failed to create user session", ResponseType.InternalServerError);


            _logger.LogInformation("Login successful for UserId: {UserId}", userExistance.UserId);
            return ApiResponse<LoginResultDto>.Success(new LoginResultDto { JwtToken = jwtToken, RefreshToken = refreshToken }, "Login Succesfuly", ResponseType.Ok);

        }
        public async Task<ApiResponse<object>> LogoutAsync(string refreshToken)
        {
            var userSession = await _unitOfWork.UserSessionRepo.GetSessionByRefreshToken(refreshToken);

            _logger.LogInformation("Logout attempt with RefreshToken");

            if (userSession == null)
            {
                _logger.LogWarning("Logout failed - invalid refresh token");
                return ApiResponse<object>.Fail("Invalid refresh token", ResponseType.BadRequest);
            }

            await _unitOfWork.UserSessions.Delete(userSession.SessionId);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("User logged out successfully. UserId: {UserId}", userSession.UserId);
            return ApiResponse<object>.Success(null!, "User logged out successfully", ResponseType.Ok);
        }

        public async Task<ApiResponse<string>> ForgetPasswordAsync(string userIdentifier)
        {
            // validate user 
            var user = await _unitOfWork.UserRepo.GetUserByIdentifier(userIdentifier);

            _logger.LogInformation("Forget password request for Identifier: {UserIdentifier}", userIdentifier);
            if (user == null)
            {
                _logger.LogWarning("Forget password failed - user not found. Identifier: {UserIdentifier}", userIdentifier);
                return ApiResponse<string>.Fail("User Not Found", ResponseType.NotFound);
            }
            var userCread = await _unitOfWork.UserCreadRepo.GetCreadbyFK(user.UserId);
            var otpcheck = OtpExpiryCheck(userCread);
            if (otpcheck != null)
                return otpcheck;

            // generate and update otp 
            var otp = new Random().Next(100000, 999999).ToString();
            var otpExpiry = DateTime.UtcNow.AddMinutes(5);
            var rowsAffected = await _unitOfWork.UserCreadRepo.UpdateOtp(otp, otpExpiry, user.UserId);
            // check is otp updated
            if (rowsAffected > 0)
            {
                // send email
                var result = await _emailManager.SendPasswordResetOtpEmail(user.Email, user.FullName, otp);

                _logger.LogInformation("Password reset OTP sent to Email: {Email}", user.Email);
                return result ? ApiResponse<string>.Success(userIdentifier, "OTP Sent to your email", ResponseType.Ok)
                    : ApiResponse<string>.Fail("Failed to send OTP email", ResponseType.InternalServerError);
            }
            return ApiResponse<string>.Success(null!, "Failed to generate OTP", ResponseType.BadRequest);

        }
        public async Task<ApiResponse<string>> ConfirmOtp(CheckOtpDto request)
        {
            _logger.LogInformation("Confirm OTP attempt for Identifier: {UserIdentifier}", request.UserIdentifier);
            var user = await _unitOfWork.UserRepo.GetUserByIdentifier(request.UserIdentifier);
            if (user == null)
                return ApiResponse<string>.Fail("User Not Found");

            // find userCreads
            var userCread = await _unitOfWork.UserCreadRepo.GetCreadbyFK(user.UserId);
            if (userCread == null)
                return ApiResponse<string>.Fail("User Creads Not Found", ResponseType.NotFound);

            //Check OTP expiry 
            if (userCread.OTPExpiry == null || userCread.OTPExpiry < DateTime.UtcNow)
                return ApiResponse<string>.Fail("OTP has expired. Please request a new one.", ResponseType.BadRequest);

            // check otp Confirmation
            if (userCread.OTP != request.Otp)
                return ApiResponse<string>.Fail("Invalid OTP", ResponseType.BadRequest);

            // check is password match
            if (request.NewPassword != request.ConfirmPassword)
                return ApiResponse<string>.Fail("Password and Confirm Password do not match", ResponseType.BadRequest);

            // update the password by mapping
            var updatedCread = userCread.UpdateCreads(request.NewPassword);
            await _unitOfWork.UserCreadRepo.Update(updatedCread);

            // and lastly Run the savechanges commond
            return await _unitOfWork.SaveChangesAsync() > 0 ? ApiResponse<string>.Success(null!, "Password Updated Succesfuly", ResponseType.Ok)
                : ApiResponse<string>.Fail("Failed to Update Password", ResponseType.InternalServerError);
        }


        //  PRIVATE HELPER METHOD
        private ApiResponse<string>? OtpExpiryCheck(UserCreadential userCreadential)
        {
            if (userCreadential == null)
                return ApiResponse<string>.Fail("User credentials not found", ResponseType.NotFound);

            if (userCreadential.OTPExpiry != null && userCreadential.OTPExpiry > DateTime.UtcNow)
            {
                var remainingTime = (userCreadential.OTPExpiry.Value - DateTime.UtcNow).TotalMinutes;
                return ApiResponse<string>.Fail(
                    $"OTP already sent. Please wait {Math.Ceiling(remainingTime)} minutes before requesting again.",
                    ResponseType.BadRequest
                );
            }

            return null;
        }

        private async Task<bool> SaveSessions(AddUserSessionDto request)
        {
            try
            {
                // if session already exist then delete it
                var userSession = await _unitOfWork.UserSessionRepo.GetSessionByFK(request.UserId);
                if (userSession != null)
                {
                    await _unitOfWork.UserSessionRepo.Delete(userSession.SessionId);
                }

                // create new sessions 
                await _unitOfWork.UserSessionRepo.Create(request.MapToDomain());
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save session for UserId: {UserId}", request.UserId);
                return false;
            }
        }

        public async Task<ApiResponse<string>> SignInAsync(LoginDto request)
        {
            _logger.LogInformation("SignIn attempt for Identifier: {UserIdentifier}", request.UserIdentifier);

            var userExistance = await _unitOfWork.UserRepo.GetUserByIdentifier(request.UserIdentifier);

            if (userExistance == null)
            {
                _logger.LogWarning("SignIn failed - user not found. Identifier: {UserIdentifier}", request.UserIdentifier);
                return ApiResponse<string>.Fail("Invalid Creadentials", ResponseType.Unauthorized);
            }

            // Check if email is verified , IF pending resend otp
            if (userExistance.Status == UserStatus.Pending)
            {
                var userCreadcheck = await _unitOfWork.UserCreadRepo.GetCreadbyFK(userExistance.UserId);
                var otpcheck = OtpExpiryCheck(userCreadcheck);
                if (otpcheck != null) return ApiResponse<string>.Fail(otpcheck.Message);

                // Generate new OTP and send email
                var otp = new Random().Next(100000, 999999).ToString();
                var otpExpiry = DateTime.UtcNow.AddMinutes(5);
                await _unitOfWork.UserCreadRepo.UpdateOtp(otp, otpExpiry, userExistance.UserId);
                await _emailManager.SendRegistrationOtpEmail(userExistance.Email, userExistance.FullName, otp);

                return ApiResponse<string>.Fail(
                    "Please verify your email before Signing in. New OTP sent to your inbox.",
                    ResponseType.Unauthorized
                );
            }

            // check creadentials
            var userCread = await _unitOfWork.UserCreadRepo.GetCreadbyFK(userExistance.UserId);
            if (userCread == null)
            {
                return ApiResponse<string>.Fail("User Creads Not Found", ResponseType.NotFound);
            }
            var isVerified = await _passwordEncriptor.VerifyPassword(request.Password, userCread.PasswordSalt, userCread.PasswordHash);

            if (!isVerified)
            {
                _logger.LogWarning("SignIn failed - invalid password. Identifier: {UserIdentifier}", request.UserIdentifier);
                return ApiResponse<string>.Fail("Invalid Creadentials", ResponseType.Unauthorized);
            }

            var userRole = await _unitOfWork.UserRoleRepo.GetUserRoles(userExistance.UserId);
            var customer = await _unitOfWork.CustomerRepo.FirstOrDefaultAsync(c => c.UserId == userExistance.UserId);
            var jwtToken = await _jwtManager.GenerateJwtToken(userExistance, userRole, customer!.ImageUrl ?? string.Empty);

            _logger.LogInformation("SignIn successful for UserId: {UserId}", userExistance.FullName);
            return ApiResponse<string>.Success(jwtToken, "SignIn successful");
        }

        #endregion 
    }
}

