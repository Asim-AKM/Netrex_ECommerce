namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IUserSessionRepo : IRepository<UserSession>
    {
        Task<UserSession?> GetSessionByRefreshToken(string refreshToken);
        Task<UserSession?> GetSessionByFK(Guid userId);
    }
}
