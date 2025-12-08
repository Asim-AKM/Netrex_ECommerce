using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserRoleRepo
    {
        Task<List<UserRole>> GetAllRoles();
        Task<UserRole> GetUserRoleByFK(Guid id);
    }
}
