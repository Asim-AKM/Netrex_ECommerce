using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UserManagmentDto_s;
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
