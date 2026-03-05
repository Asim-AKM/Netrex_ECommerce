namespace Application_Service.Security.Jwt
{
    public interface IJwtManager
    {
        Task<string> GenerateJwtToken(User user, List<RoleType> role);
    }
}
