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

        public async Task<ApiResponse<string>> RefreshJwtToken(string refreshToken)
        {
            try
            {
                // Validate the refresh token
                var userSession = await _unitOfWork.UserSessionRepository.GetSessionByRefreshToken(refreshToken);
                if (userSession == null)
                    return ApiResponse<string>.Fail("Invalid refresh token", ResponseType.BadRequest);
                if (userSession.ExpireAt < DateTime.UtcNow)
                    return ApiResponse<string>.Fail("Refresh token has expired", ResponseType.BadRequest);

                // Generate new JWT token
                var user = await _unitOfWork.Users.GetById(userSession.UserId);
                var userRoles = await _unitOfWork.UserRoleRepository.GetUserRoles(userSession.UserId);
                var jwtToken = await _jwtManager.GenerateJwtToken(user, userRoles);

                return ApiResponse<string>.Success(jwtToken, "Jwt token refreshed successfully", ResponseType.Ok);
            }
            catch
            {
                return ApiResponse<string>.Fail("An error occurred during refreshing the JwtToken", ResponseType.InternalServerError);
            }
        }
    }
}
