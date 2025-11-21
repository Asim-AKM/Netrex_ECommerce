using Domain_Service.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.RepoInterfaces.Users
{
    public interface IUserRepo
    {
        Task UserRegistration(User user);

    }
}
