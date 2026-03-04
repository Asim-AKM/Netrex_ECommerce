using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserRoleRepo : IRepository<UserRole>
    {
        Task AddUserRole(UserRole role);
        Task<UserRole> GetRolebyFK(Guid userId);
        Task<List<RoleType>> GetUserRoles(Guid userId);
    }
}
