using Domain_Service.Entities.UserModule.Roles;
using Domain_Service.Entities.UserModule.Users;
using Domain_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.UserRoleMappers
{
    public static class AddUserRoleMapper
    {
        public static UserRole AssingRole( this User user)
        {
            return new UserRole
            {
                UR_Id = Guid.NewGuid(),
                UserId = user.U_Id,
                RoleName = RoleType.Customer,
            };
        }
    }
}
