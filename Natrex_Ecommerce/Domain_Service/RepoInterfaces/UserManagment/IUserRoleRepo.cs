using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserRoleRepo
    {
        Task AddUserRole(UserRole role);
    }
}
