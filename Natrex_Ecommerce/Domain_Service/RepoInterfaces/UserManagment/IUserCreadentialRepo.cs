using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserCreadentialRepo
    {
        Task<UserCreadential> GetUserCredentialByFK(Guid id);
    }
}
