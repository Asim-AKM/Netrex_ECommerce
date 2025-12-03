using Domain_Service.Entities.UserManagmentModule;

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
