namespace Application_Service.DTO_s.UserManagmentDto_s
{
    
    // DTO for verifying email during registration
   
    public record VerifyRegistrationOtpDto(string Email, string Otp);
}
