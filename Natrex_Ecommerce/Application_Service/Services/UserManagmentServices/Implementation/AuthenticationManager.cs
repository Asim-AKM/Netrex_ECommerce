using Application_Service.Common.APIResponses;
using Application_Service.Common.Email;
using Application_Service.Common.Mappers.UserManagmentMapppers;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncriptor _passwordEncriptor;
        public AuthenticationManager(IUnitOfWork unitOfWork, IPasswordEncriptor passwordEncriptor)
        {
            _unitOfWork = unitOfWork;
            _passwordEncriptor = passwordEncriptor;
        }

        public async Task<ApiResponse<CreateUserDto>> CreateUserAsync(CreateUserDto request)
        {
            //Validate User
            var userExistance = await _unitOfWork.UserRepository.GetUserByIdentifier(request.username);
            if (userExistance != null)
            {
                List<string> errorsList = new List<string>();
                if (userExistance.Email == request.email)
                    errorsList.Add("Email already exist");
                if (userExistance.UserName == request.username)
                    errorsList.Add("UserNAme already exist");
                if (userExistance.Contact == request.contact)
                    errorsList.Add("Contact already exist");
                var error = string.Join(" | ", errorsList);
                return ApiResponse<CreateUserDto>.Fail(error, ResponseType.Conflict);
            }

            var user = request.MapToDomain();
            await _unitOfWork.Users.Create(user);
            await _unitOfWork.UserCreads.Create(user.AssignCreads(request.password));
            await _unitOfWork.UserRoles.Create(user.AssingRole());
            ;
            return await _unitOfWork.SaveChangesAsync() > 0 ? ApiResponse<CreateUserDto>.Success(request, "User Created Succesfuly", ResponseType.Created)
                : ApiResponse<CreateUserDto>.Fail("Failed to Create User", ResponseType.BadRequest);
        }

        public async Task<ApiResponse<string>> ForgetPasswordAsync(string userIdentifier)
        {
            // validate user 
            var user = await _unitOfWork.UserRepository.GetUserByIdentifier(userIdentifier);
            if (user == null) { return ApiResponse<string>.Fail("User Not Found", ResponseType.NotFound); }
            // generate and update otp 
            var otp = new Random().Next(100000, 999999).ToString();
            await _unitOfWork.UserCreadRepository.UpdateOtp(otp, user.UserId);
            // check is otp updated
            if (await _unitOfWork.SaveChangesAsync() > 0)
            {
                // send email
                var result = await MailService.SendEmailAsync(user.Email, "Password Reset OTP", $"Your OTP for password reset is: {otp}"); 
                return result ? ApiResponse<string>.Success(null!, "OTP Sent to your email", ResponseType.Ok)
                    : ApiResponse<string>.Fail("Failed to send OTP email", ResponseType.InternalServerError);
            }
            return ApiResponse<string>.Success(null!, "Failed to generate OTP", ResponseType.BadRequest);

        }

        public async Task<ApiResponse<string>> LoginAsync(LoginDto request)
        {
            var userExistance = await _unitOfWork.UserRepository.GetUserByIdentifier(request.UserIdentifier);
            if (userExistance == null)
            {
                return ApiResponse<string>.Fail("Invalid Creadentials", ResponseType.Unauthorized);
            }
            var userCread = await _unitOfWork.UserCreads.GetById(userExistance.UserId);
            var isVerified = await _passwordEncriptor.VerifyPassword(request.Password, userCread.PasswordSalt, userCread.PasswordHash);

            if (isVerified)
            {
                // the work of JWt token genartion is in progress
                return ApiResponse<string>.Success(default!, "Login Succesfuly", ResponseType.Ok);
            }

            return ApiResponse<string>.Fail("Invalid Creadentials", ResponseType.Unauthorized);

        }
    }
}
