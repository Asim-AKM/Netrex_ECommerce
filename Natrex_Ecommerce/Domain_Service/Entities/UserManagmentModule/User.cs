using Domain_Service.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.UserManagmentModule
{
    /// <summary>
    /// Represents an application user entity containing identity, profile, 
    /// contact details, and status information. This model is typically used 
    /// for authentication, authorization, and general user management across the system.
    /// </summary>
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// The user's full legal or display name.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// URL of the user's profile image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Unique username chosen for login or identification.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// The user's email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The user's contact phone number.
        /// </summary>
        public string Contact { get; set; } = string.Empty;

        /// <summary>
        /// Indicates the current account status (Active, Inactive, Blocked, etc.).
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// The date the account was created (date only).
        /// </summary>
        public DateOnly CreateAt { get; set; }

        /// <summary>
        /// The most recent date and time the record was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
