using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.Enums;

namespace Application_Service.Security.Jwt
{
    public interface IJwtManager
    {
        Task<string> GenerateJwtToken(User user, List<RoleType> role);
    }
}
