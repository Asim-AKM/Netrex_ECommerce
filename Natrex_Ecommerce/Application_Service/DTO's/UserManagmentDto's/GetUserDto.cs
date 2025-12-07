using Domain_Service.Enums;

namespace Application_Service.DTO_s.UserManagmentDto_s
{
    //public record GetUserDto(Guid Id, string FullName, string Username, string Email, string ImageUrl, string Contact, UserStatus Userstatus, DateTime CreateAt, RoleType RoleName);
    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = "";
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string Contact { get; set; } = "";
        public UserStatus Userstatus { get; set; }
        public DateOnly CreateAt { get; set; }
        public RoleType RoleName { get; set; }
    }


}
