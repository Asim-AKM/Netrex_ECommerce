using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.Enums;

namespace Application_Service.Common.Mappers.UserRoleMappers
{
    public static class AddUserRoleMapper
    {
        public static UserRole AssingRole( this User user)
        {
            return new UserRole
            {
                UserRoleId = Guid.NewGuid(),
                UserId = user.UserId,
                RoleName = RoleType.Customer,
            };
        }
    }
}
