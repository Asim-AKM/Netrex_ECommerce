using Domain_Service.Entities.UserCredentials;
using Domain_Service.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.UserCreadentialMappers
{
    public static class AddUserCreadentialMappers
    {
        public static UserCreadential AssingToCreadential(this User user)
        {
            return new UserCreadential
            {
                Cread_Id = Guid.NewGuid(),
                U_Id = user.U_Id,
            };
        }



       
    }
}
