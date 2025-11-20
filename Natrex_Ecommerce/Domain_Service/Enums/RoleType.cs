namespace Domain_Service.Enums
{
    /// <summary>
    /// Specifies the different types of user roles available within the system.
    /// Roles determine the level of access and permissions assigned to a user.
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// Administrator role with full system access and management privileges.
        /// </summary>
        Admin = 1,

        /// <summary>
        /// Standard user role with limited access to general application features.
        /// </summary>
        User = 2,

        /// <summary>
        /// Customer role typically used for clients or end-users interacting with the system.
        /// </summary>
        Customer = 3,

        /// <summary>
        /// Seller role with access to product, inventory, and order management features.
        /// </summary>
        Seller = 4
    }
}
