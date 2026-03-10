namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class UserSessionManager : IUserSessionManager
    {
        #region Dependencies
        //private readonly IRepository<UserSession> _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtManager _jwtManager;

        public UserSessionManager(IJwtManager jwtManager, IUnitOfWork unitOfWork)
        {
            _jwtManager = jwtManager;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public async Task<ApiResponse<string>> RefreshJwt(Guid userId)
        {
            var user = await _unitOfWork.UserRepo.GetById(userId);
            if (user == null)
                return ApiResponse<string>.Fail("User not found", ResponseType.NotFound);

            // Generate new JWT token
            var userRoles = await _unitOfWork.UserRoleRepo.GetUserRoles(userId);
            var customer = await _unitOfWork.CustomerRepo.FirstOrDefaultAsync(c => c.UserId == user.UserId);
            var jwtToken = await _jwtManager.GenerateJwtToken(user, userRoles, customer!.ImageUrl ?? string.Empty);

            return ApiResponse<string>.Success(jwtToken, "Jwt token refreshed successfully", ResponseType.Ok);
        }

        public async Task<ApiResponse<string>> RefreshJwtToken(string refreshToken)
        {
            try
            {
                // Validate the refresh token
                var userSession = await _unitOfWork.UserSessionRepo.GetSessionByRefreshToken(refreshToken);
                if (userSession == null)
                    return ApiResponse<string>.Fail("Invalid refresh token", ResponseType.BadRequest);
                if (userSession.ExpireAt < DateTime.UtcNow)
                    return ApiResponse<string>.Fail("Refresh token has expired", ResponseType.BadRequest);

                // Generate new JWT token
                var user = await _unitOfWork.UserRepo.GetById(userSession.UserId);
                var userRoles = await _unitOfWork.UserRoleRepo.GetUserRoles(userSession.UserId);
                var customer = await _unitOfWork.CustomerRepo.FirstOrDefaultAsync(c => c.UserId == user.UserId);
                var jwtToken = await _jwtManager.GenerateJwtToken(user, userRoles, customer!.ImageUrl ?? string.Empty);

                return ApiResponse<string>.Success(jwtToken, "Jwt token refreshed successfully", ResponseType.Ok);
            }
            catch
            {
                return ApiResponse<string>.Fail("An error occurred during refreshing the JwtToken", ResponseType.InternalServerError);
            }
        }

    }
}
