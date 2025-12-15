using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserCreadentialRepo
    {
        Task UpdateOtp(string otp,Guid userId);
        Task<UserCreadential> GetCreadbyFK(Guid userId);
    }
}
