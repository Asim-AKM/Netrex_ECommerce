namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IUserSessionManager
    {
        Task<ApiResponse<string>> RefreshJwtToken(string refreshToken);
        Task<ApiResponse<string>> RefreshJwt(Guid userId);
    }
}
