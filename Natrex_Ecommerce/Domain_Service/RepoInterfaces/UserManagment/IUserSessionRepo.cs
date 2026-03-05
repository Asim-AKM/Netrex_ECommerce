namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IUserSessionRepo
    {
        Task<UserSession?> GetSessionByRefreshToken(string refreshToken);
        Task<UserSession?> GetSessionByFK(Guid userId);
    }
}
