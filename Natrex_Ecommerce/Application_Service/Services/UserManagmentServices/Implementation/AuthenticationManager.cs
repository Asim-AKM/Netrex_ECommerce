using Application_Service.Common.APIResponses;
using Application_Service.Common.Email;
using Application_Service.Common.Mappers.UserManagmentMapppers;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Security.Jwt;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.UnitOfWork;
using MailKit;
using System.Runtime.Intrinsics.Arm;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncriptor _passwordEncriptor;
        private readonly IJwtManager _jwtManager;
        private readonly IEmailManager _emailManager;
        public AuthenticationManager(IUnitOfWork unitOfWork, IPasswordEncriptor passwordEncriptor, IJwtManager jwtManager, IEmailManager emailManager)
        {
            _unitOfWork = unitOfWork;
            _passwordEncriptor = passwordEncriptor;
            _jwtManager = jwtManager;
            _emailManager = emailManager;
        }

        public async Task<ApiResponse<CreateUserDto>> CreateUserAsync(CreateUserDto request)
        {
            // Validate UserIdentifier for Unique Entry
            var emailExistance = await _unitOfWork.UserRepository.GetUserByIdentifier(request.Email);
            var userNameExistance = await _unitOfWork.UserRepository.GetUserByIdentifier(request.UserName);
            // Acomulate Errors in a list 
            if (emailExistance != null || userNameExistance != null)
            {
                List<string> errorsList = new List<string>();
                if (emailExistance != null)
                    errorsList.Add("Email Already Exist");
                if (userNameExistance != null)
                    errorsList.Add("UserName Already Exist");

                var error = string.Join(" | ", errorsList);
                return ApiResponse<CreateUserDto>.Fail(error, ResponseType.Conflict);
            }

            // Create a user through generic repo
            var user = request.MapToDomain();
            await _unitOfWork.Users.Create(user);
            await _unitOfWork.UserCreads.Create(user.AssignCreads(request.Password));
            await _unitOfWork.UserRoles.Create(user.AssingRole());

            //Save to database
            var saved = await _unitOfWork.SaveChangesAsync() > 0;

            if (!saved)
                return ApiResponse<CreateUserDto>.Fail("Failed to Create User", ResponseType.BadRequest);

            // Generate and send OTP
            var otp = new Random().Next(100000, 999999).ToString();
            var otpExpiry = DateTime.UtcNow.AddMinutes(10); // ADDED EXPIRY
            var otpUpdated = await _unitOfWork.UserCreadRepository.UpdateOtp(otp, otpExpiry, user.UserId); // UPDATED

            if (otpUpdated > 0)
            {
                // Send OTP email using new email service
                var emailSent = await _emailManager.SendRegistrationOtpEmail(user.Email, user.FullName, otp); 

                if (emailSent)
                {
                    return ApiResponse<CreateUserDto>.Success(
                        request,
                        "User created successfully. Please verify your email with the OTP sent to your inbox.",
                        ResponseType.Created
                    );
                }
            }

            return ApiResponse<CreateUserDto>.Fail("User created but failed to send verification email. Please use resend OTP.", ResponseType.InternalServerError);
        }

        public async Task<ApiResponse<string>> VerifyRegistrationOtpAsync(VerifyRegistrationOtpDto request) 
        {
            // Find user by email
            var user = await _unitOfWork.UserRepository.GetUserByIdentifier(request.Email);

            if (user == null)
                return ApiResponse<string>.Fail("User not found", ResponseType.NotFound);

            // Check if already verified
            if (user.Status == UserStatus.Active)
                return ApiResponse<string>.Fail("Email already verified. You can login now.", ResponseType.BadRequest);

            // Get user credentials
            var userCread = await _unitOfWork.UserCreadRepository.GetCreadbyFK(user.UserId);

            if (userCread == null)
                return ApiResponse<string>.Fail("User credentials not found", ResponseType.NotFound);

            // Check OTP expiry
            if (userCread.OTPExpiry == null || userCread.OTPExpiry < DateTime.UtcNow)
                return ApiResponse<string>.Fail("OTP has expired. Please request a new one.", ResponseType.BadRequest);

            // Verify OTP
            if (userCread.OTP != request.Otp)
                return ApiResponse<string>.Fail("Invalid OTP. Please check and try again.", ResponseType.BadRequest);

            // Update user status to Active
            user.Status = UserStatus.Active;
            user.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Users.Update(user);

            // Clear OTP
            await _unitOfWork.UserCreadRepository.UpdateOtp(string.Empty, null, user.UserId);

            // Save changes
            var saved = await _unitOfWork.SaveChangesAsync() > 0;

            if (saved)
            {
                // send welcome email
                await _emailManager.SendWelcomeEmail(user.Email, user.FullName);

                return ApiResponse<string>.Success(null!, "Email verified successfully! You can now login.", ResponseType.Ok);
            }

            return ApiResponse<string>.Fail("Failed to verify email", ResponseType.InternalServerError);
        }

        public async Task<ApiResponse<string>> ResendRegistrationOtpAsync(string email)
        {
            // Find user by email
            var user = await _unitOfWork.UserRepository.GetUserByIdentifier(email);

            if (user == null)
                return ApiResponse<string>.Fail("User not found", ResponseType.NotFound);

            // Check if already verified
            if (user.Status == UserStatus.Active)
                return ApiResponse<string>.Fail("Email already verified. You can login now.", ResponseType.BadRequest);

            // Generate new OTP
            var otp = new Random().Next(100000, 999999).ToString();
            var otpExpiry = DateTime.UtcNow.AddMinutes(5);
            var otpUpdated = await _unitOfWork.UserCreadRepository.UpdateOtp(otp, otpExpiry, user.UserId);

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
        public async Task<ApiResponse<string>> LoginAsync(LoginDto request)
        {
            var userExistance = await _unitOfWork.UserRepository.GetUserByIdentifier(request.UserIdentifier);
            if (userExistance == null)
            {
                return ApiResponse<string>.Fail("Invalid Creadentials", ResponseType.Unauthorized);
            }

            // Check if email is verified
            if (userExistance.Status == UserStatus.Pending) 
                return ApiResponse<string>.Fail("Please verify your email before logging in. Check your inbox for OTP.", ResponseType.Unauthorized);
            
            // check creadentials
            var userCread = await _unitOfWork.UserCreadRepository.GetCreadbyFK(userExistance.UserId);
            if (userCread == null)
            {
                return ApiResponse<string>.Fail("User Creads Not Found", ResponseType.NotFound);
            }
            var isVerified = await _passwordEncriptor.VerifyPassword(request.Password, userCread.PasswordSalt, userCread.PasswordHash);

            if (isVerified)
            {
                var userRole = await _unitOfWork.UserRoleRepository.GetUserRoles(userExistance.UserId);
                var jwtToken = await _jwtManager.GenerateJwtToken(userExistance, userRole);
                return ApiResponse<string>.Success(jwtToken, "Login Succesfuly", ResponseType.Ok);
            }
            return ApiResponse<string>.Fail("Invalid Creadentials", ResponseType.Unauthorized);

        }

        public async Task<ApiResponse<string>> ForgetPasswordAsync(string userIdentifier)
        {
            // validate user 
            var user = await _unitOfWork.UserRepository.GetUserByIdentifier(userIdentifier);
            if (user == null) { return ApiResponse<string>.Fail("User Not Found", ResponseType.NotFound); }
            // generate and update otp 
            var otp = new Random().Next(100000, 999999).ToString();
            var otpExpiry = DateTime.UtcNow.AddMinutes(5);
            var rowsAffected = await _unitOfWork.UserCreadRepository.UpdateOtp(otp, otpExpiry, user.UserId);
            // check is otp updated
            if (rowsAffected > 0)
            {
                // send email
                var result = await _emailManager.SendPasswordResetOtpEmail(user.Email, user.FullName, otp);
                return result ? ApiResponse<string>.Success(userIdentifier, "OTP Sent to your email", ResponseType.Ok)
                    : ApiResponse<string>.Fail("Failed to send OTP email", ResponseType.InternalServerError);
            }
            return ApiResponse<string>.Success(null!, "Failed to generate OTP", ResponseType.BadRequest);

        }
        public async Task<ApiResponse<string>> ConfirmOtp(CheckOtpDto request)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdentifier(request.UserIdentifier);
            if (user == null)
                return ApiResponse<string>.Fail("User Not Found");

            // find userCreads
            var userCread = await _unitOfWork.UserCreadRepository.GetCreadbyFK(user.UserId);
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
            await _unitOfWork.UserCreads.Update(updatedCread);

            // and lastly Run the savechanges commond
            return await _unitOfWork.SaveChangesAsync() > 0 ? ApiResponse<string>.Success(null!, "Password Updated Succesfuly", ResponseType.Ok)
                : ApiResponse<string>.Fail("Failed to Update Password", ResponseType.InternalServerError);
        }

    }
}
