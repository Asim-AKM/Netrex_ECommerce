using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.GenericRepo
{
    public  interface IUserCreadentialRepo
    {
        Task AddUserCreadential(UserCreadential userCreadential);
    }
}
