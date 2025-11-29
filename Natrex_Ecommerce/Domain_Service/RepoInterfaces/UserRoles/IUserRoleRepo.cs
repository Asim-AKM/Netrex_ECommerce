using Domain_Service.Entities.UserModule.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.RepoInterfaces.UserRoles
{
    public  interface IUserRoleRepo
    {
        Task AddUserRole(UserRole role);
    }
}
