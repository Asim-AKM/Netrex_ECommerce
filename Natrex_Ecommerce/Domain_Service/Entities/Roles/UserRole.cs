using Domain_Service.Enums;

namespace Domain_Service.Entities.Roles
{
    /// <summary>
    /// Represents a user role within the system, defining the type of access 
    /// or permissions assigned to a user. Each role helps categorize users 
    /// for authorization and functionality access.
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Unique identifier for the user role.
        /// </summary>
        public Guid UR_Id { get; set; }

        /// <summary>
        /// The specific role assigned (e.g., Admin, User, Manager), 
        /// represented by the <see cref="RoleType"/> enumeration.
        /// </summary>
        public RoleType Role { get; set; }
    }
}
