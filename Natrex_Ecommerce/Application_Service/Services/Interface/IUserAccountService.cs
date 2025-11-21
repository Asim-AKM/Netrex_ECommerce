using Application_Service.DTO_s.UsersDto.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.Interface
{
    public interface IUserAccountService
    {
        Task<string> UserRegistrationAsync(UserRegisterDto Request);
    }
}
