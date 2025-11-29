using Domain_Service.Entities.UserModule.UserCredentials;
using Domain_Service.RepoInterfaces.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.UserCreadentials
{
    public class UserCreadentialRepo : IUserCreadentialRepo
    {
        public Task AddUserCreadential(UserCreadential userCreadential)
        {
            throw new NotImplementedException();
        }
    }
}
