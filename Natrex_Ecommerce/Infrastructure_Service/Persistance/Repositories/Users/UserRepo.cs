using Domain_Service.Entities.UserModule.Users;
using Domain_Service.RepoInterfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.Users
{
    internal class UserRepo : IUserRepo
    {
        public Task UserRegistration(User user)
        {
            throw new NotImplementedException();
        }
    }
}
