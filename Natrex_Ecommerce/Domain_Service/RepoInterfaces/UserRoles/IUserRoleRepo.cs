using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserRoles
{
    public  interface IUserRoleRepo
    {
        Task AddUserRole(UserRole role);
    }
}
