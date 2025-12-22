using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.Enums;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserRoleRepo
    {
        Task AddUserRole(UserRole role);
        Task<UserRole> GetRolebyFK(Guid userId);
        Task<List<RoleType>> GetUserRoles(Guid userId);
    }
}
