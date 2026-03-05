namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserRoleRepo : IRepository<UserRole>
    {
        Task AddUserRole(UserRole role);
        Task<UserRole> GetRolebyFK(Guid userId);
        Task<List<RoleType>> GetUserRoles(Guid userId);
    }
}
