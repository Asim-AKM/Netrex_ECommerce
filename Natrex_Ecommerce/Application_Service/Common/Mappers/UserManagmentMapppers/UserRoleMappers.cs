using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.Enums;

namespace Application_Service.Common.Mappers.UserManagmentMapppers
{
    public static class UserRoleMappers
    {
        public static UserRole AssingRole(this User user)
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
