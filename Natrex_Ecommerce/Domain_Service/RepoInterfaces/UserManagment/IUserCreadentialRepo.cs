using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserCreadentialRepo
    {
        Task AddUserCreadential(UserCreadential userCreadential);
        Task UpdateOtp(string otp,Guid userId);
    }
}
