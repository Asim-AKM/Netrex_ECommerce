using Application_Service.Common.APIResponses;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IUserSessionManager
    {
        Task<ApiResponse<string>> RefreshJwtToken(string refreshToken);
    }
}
