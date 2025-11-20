namespace Domain_Service.Enums
{
    /// <summary>
    /// Defines the various status states that a user account can have within the system.
    /// This helps manage accessibility, account lifecycle, and operational control.
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// The user account is active and fully functional.
        /// </summary>
        Active = 1,

        /// <summary>
        /// The user account is inactive and may require verification or reactivation.
        /// </summary>
        Inactive = 2,

        /// <summary>
        /// The user account has been temporarily suspended due to violations or administrative action.
        /// </summary>
        Suspended = 3,

        /// <summary>
        /// The user account has been permanently removed from the system.
        /// </summary>
        Deleted = 4
    }
}
