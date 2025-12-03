using Domain_Service.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.UserManagmentModule.Roles
{
    /// <summary>
    /// Represents a user role within the system, defining the type of access 
    /// or permissions assigned to a user. Each role helps categorize users 
    /// for authorization and functionality access.
    /// </summary>
    public class UserRole
    {
        [Key]
        /// <summary>
        /// Unique identifier for the user role.
        /// </summary>
        /// 
        public Guid UR_Id { get; set; }
       
        public  RoleType RoleName { get; set; }

        public Guid UserId { get; set; }

    }
}
