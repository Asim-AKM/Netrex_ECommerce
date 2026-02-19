using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.UserManagmentModule
{
    /// <summary>
    /// Represents a user session in the system.
    /// Each session is linked to a specific user and contains
    /// a refresh token for issuing new JWT access tokens.
    /// </summary>
    public class UserSession
    {
        /// <summary>
        /// Primary key for the session.
        /// This uniquely identifies a user session in the database.
        /// </summary>
        [Key]
        public Guid SessionId { get; set; }

        /// <summary>
        /// The ID of the user to whom this session belongs.
        /// Used to link the session to a specific user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The refresh token associated with this session.
        /// Used to generate new JWT access tokens when the previous one expires.
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether this session has been revoked.
        /// A revoked session cannot be used to refresh JWT tokens.
        /// </summary>
        public bool IsRevoked { get; set; } = false;

        /// <summary>
        /// The timestamp when the session was revoked.
        /// Null if the session is still active.
        /// </summary>
        public DateTime? RevokedAt { get; set; }

        /// <summary>
        /// The expiration date and time of the session's refresh token.
        /// After this time, the refresh token cannot be used to generate new JWTs.
        /// </summary>
        public DateTime ExpireAt { get; set; }

        /// <summary>
        /// The timestamp when this session was created.
        /// Useful for auditing and tracking when the session started.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The timestamp when this session was last updated.
        /// Should be updated whenever the session is refreshed or modified.
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }
    }
}
