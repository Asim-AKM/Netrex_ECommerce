using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Enums
{
    /// <summary>
    /// Represents standardized API response types mapped to HTTP status codes.
    /// This enum helps the service layer communicate the intended response type
    /// back to the controller in a clean and consistent way.
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// The request was successful and data is returned.
        /// Corresponds to HTTP 200 OK.
        /// </summary>
        Ok = 200,

        /// <summary>
        /// The request was successful and a new resource was created.
        /// Corresponds to HTTP 201 Created.
        /// </summary>
        Created = 201,

        /// <summary>
        /// The request was successful but no content is returned.
        /// Corresponds to HTTP 204 No Content.
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// The request is invalid or contains validation errors.
        /// Corresponds to HTTP 400 Bad Request.
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Authentication is required or failed.
        /// Corresponds to HTTP 401 Unauthorized.
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// The client is authenticated but does not have permission to access the resource.
        /// Corresponds to HTTP 403 Forbidden.
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// The requested resource was not found.
        /// Corresponds to HTTP 404 Not Found.
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// A conflict occurred (e.g., duplicate email, username already exists).
        /// Corresponds to HTTP 409 Conflict.
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// An unexpected error occurred on the server.
        /// Corresponds to HTTP 500 Internal Server Error.
        /// </summary>
        InternalServerError = 500
    }
}
