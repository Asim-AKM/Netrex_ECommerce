namespace Application_Service.DTO_s.UserManagmentDto_s
{
    // UserId in this context comes from the Email Verification form when a user succefully verify email 
    public record CheckOtpDto(string UserIdentifier, string Otp, string NewPassword, string ConfirmPassword);
}
