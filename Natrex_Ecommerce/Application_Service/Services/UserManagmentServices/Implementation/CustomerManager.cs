using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.UserManagmentMapppers;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<string>> DeleteCustomer(Guid customerId)
        {
            var customer = await _unitOfWork.Customers.GetById(customerId);
            if (customer == null)
                return ApiResponse<string>.Fail("Customer Not Found", ResponseType.NotFound);

            await _unitOfWork.Customers.Delete(customer.CustomerId);

            var user = await _unitOfWork.Users.GetById(customer.UserId);
            if (user != null)
            {
                var userCred = await _unitOfWork.UserCreads.FirstOrDefaultAsync(x => x.UserId == user.UserId);
                if (userCred != null)
                    await _unitOfWork.UserCreads.Delete(userCred.CreadId);

                var userRole = await _unitOfWork.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.UserId);
                if (userRole != null)
                    await _unitOfWork.UserRoles.Delete(userRole.UserRoleId);

                await _unitOfWork.Users.Delete(user.UserId);
            }


            return await _unitOfWork.SaveChangesAsync() > 0 ? ApiResponse<string>.Success(default!, "Deleted Succesfuly") : ApiResponse<string>.Fail("Internal server Error", ResponseType.InternalServerError);

        }

        public async Task<ApiResponse<List<GetCustomerDto>>> GetAllCustomers()
        {
            var customers = await _unitOfWork.Customers.GetAll();
            return customers.Count > 0 ? ApiResponse<List<GetCustomerDto>>.Success(customers.MapToGetAllDto(), " Customer List Retrieved Succesfuly ") : ApiResponse<List<GetCustomerDto>>.Fail("List is Empty", ResponseType.NotFound);
        }

        public async Task<ApiResponse<string>> UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            var domain = await _unitOfWork.Customers.GetById(updateCustomer.UserId);
            if (domain == null)
                return ApiResponse<string>.Fail("Customer Not Found ", ResponseType.NotFound);

            await _unitOfWork.Customers.Update(updateCustomer.MapToDomain());
            return await _unitOfWork.SaveChangesAsync() > 0 ? ApiResponse<string>.Success(default!, "Customer Update Succesfully") : ApiResponse<string>.Fail("Internal Server Error", ResponseType.InternalServerError);
        }

    }
}

