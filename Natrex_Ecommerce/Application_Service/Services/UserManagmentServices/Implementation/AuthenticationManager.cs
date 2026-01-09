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

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncriptor _passwordEncriptor;
        private readonly IJwtManager _jwtManager;
        public AuthenticationManager(IUnitOfWork unitOfWork, IPasswordEncriptor passwordEncriptor, IJwtManager jwtManager)
        {
            _unitOfWork = unitOfWork;
            _passwordEncriptor = passwordEncriptor;
            _jwtManager = jwtManager;
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

            // Create a user thriugh generic repo
            var user = request.MapToDomain();
            await _unitOfWork.Users.Create(user);
            await _unitOfWork.UserCreads.Create(user.AssignCreads(request.Password));
            await _unitOfWork.UserRoles.Create(user.AssingRole());

            return await _unitOfWork.SaveChangesAsync() > 0 ? ApiResponse<CreateUserDto>.Success(request, "User Created Succesfuly", ResponseType.Created)
                : ApiResponse<CreateUserDto>.Fail("Failed to Create User", ResponseType.BadRequest);
        }
        public async Task<ApiResponse<string>> LoginAsync(LoginDto request)
        {
            var userExistance = await _unitOfWork.UserRepository.GetUserByIdentifier(request.UserIdentifier);
            if (userExistance == null)
            {
                return ApiResponse<string>.Fail("Invalid Creadentials", ResponseType.Unauthorized);
            }
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
            var rowsAffected = await _unitOfWork.UserCreadRepository.UpdateOtp(otp, user.UserId);
            // check is otp updated
            if (rowsAffected > 0)
            {
                // send email
                var result = await MailService.SendEmailAsync(user.Email, "Password Reset OTP", $"Your OTP for password reset is: {otp}");
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
