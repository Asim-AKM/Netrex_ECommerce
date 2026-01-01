using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.UserManagmentMapppers;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _uOW;
        public UserManager(IUnitOfWork uOW)
        {
            _uOW = uOW;
        }
        public async Task<ApiResponse<string>> DeleteUserAsync(Guid id)
        {
            var user = await _uOW.Users.GetById(id);
            if (user == null)
                return ApiResponse<string>.Fail("User Not Found",ResponseType.Conflict);

            var cred = await _uOW.UserCreads.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (cred != null)
                await _uOW.UserCreads.Delete(cred.CreadId); 

            var role = await _uOW.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (role != null)
                await _uOW.UserRoles.Delete(role.UserRoleId); 

            await _uOW.Users.Delete(user.UserId); 

            await _uOW.SaveChangesAsync();
            return ApiResponse<string>.Success(default!, "Data Deleted Successfully");

        }

        public async Task<ApiResponse<List<GetUsersDto>>> GetAllUserAsync()
        {
            var user = await _uOW.Users.GetAll();
            var role = await _uOW.UserRoles.GetAll();
            var data = (from u in user
                        join r in role
                        on u.UserId equals r.UserId
                        select new GetUsersDto
                        {
                            Id = u.UserId,
                            FullName = u.FullName,
                            Contact = u.Contact,
                            CreateAt = u.CreateAt,
                            Email = u.Email,
                            ImageUrl = u.ImageUrl,
                            RoleName = r.RoleName,
                            Username = u.UserName,
                            Userstatus = u.Status,
                        }).ToList();
            return ApiResponse<List<GetUsersDto>>.Success(data,"Users fetched successfully");
        }

        public async Task<ApiResponse<string>> UpdateUserAsync(UpdateUserDto updateuser)
        {
            var domain = await _uOW.Users.GetById(updateuser.Id);
            if (domain != null)
            {
                await _uOW.Users.Update(updateuser.MapToDomain());
                return await _uOW.SaveChangesAsync() > 0 ? ApiResponse<string>.Success(default!, "Update Succesfully") : ApiResponse<string>.Fail("Internal Server Error", ResponseType.InternalServerError);

            }
            return ApiResponse<string>.Fail("Data Not Found ", ResponseType.NotFound);
        }
    }
}
