namespace Domain_Service.RepoInterfaces.UserManagment
{
    public  interface IUserCreadentialRepo : IRepository<UserCreadential>
    {
        Task<int> UpdateOtp(string otp,DateTime? otpExpiry,Guid userId);
        Task<UserCreadential> GetCreadbyFK(Guid userId);
    }
}
