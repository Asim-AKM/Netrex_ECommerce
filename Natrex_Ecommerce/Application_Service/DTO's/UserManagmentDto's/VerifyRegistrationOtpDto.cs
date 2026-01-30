using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.UserManagmentDto_s
{
    
    // DTO for verifying email during registration
   
    public record VerifyRegistrationOtpDto(string Email, string Otp);
}
