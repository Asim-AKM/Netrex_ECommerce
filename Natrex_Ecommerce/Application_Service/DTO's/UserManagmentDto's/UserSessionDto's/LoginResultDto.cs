namespace Application_Service.DTO_s.UserManagmentDto_s.UserSessionDto_s
{
    public class LoginResultDto
    {
        public string JwtToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
