namespace Domain_Service.Entities.UserManagmentModule.UserCredentials
{
    /// <summary>
    /// Represents the authentication credentials associated with a user.
    /// This includes password hashing details and optional OTP verification data.
    /// </summary>
    public class UserCreadential
    {
        /// <summary>
        /// Unique identifier for the user credential record.
        /// </summary>
        public Guid Cread_Id { get; set; }

        /// <summary>
        /// Foreign key referencing the associated user entity.
        /// </summary>
        public Guid U_Id { get; set; }

        /// <summary>
        /// Cryptographically hashed password stored for secure authentication.
        /// </summary>
        public byte[] PasswordHash { get; set; } = [];

        /// <summary>
        /// Unique salt used during password hashing to enhance security.
        /// </summary>
        public byte[] PasswordSalt { get; set; } = [];

        /// <summary>
        /// One-time password (OTP) used for verification or multi-factor authentication.
        /// </summary>
        public string OTP { get; set; } = string.Empty;
    }
}
