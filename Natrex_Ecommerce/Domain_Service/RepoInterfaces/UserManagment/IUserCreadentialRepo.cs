using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserCreadentialRepo
    {
        Task<int> UpdateOtp(string otp,Guid userId);
        Task<UserCreadential> GetCreadbyFK(Guid userId);
    }
}
