namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryManager _cloudinaryManager;
        public CustomerManager(IUnitOfWork unitOfWork, ICloudinaryManager cloudinaryManager)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryManager = cloudinaryManager;
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
        public async Task<ApiResponse<string>> UpdateProfileImage(Guid userId, IFormFile file)
        {
            var customer = await _unitOfWork.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
            if (customer == null)
                return ApiResponse<string>.Fail("Customer Not Found", ResponseType.NotFound);
            try
            {
                if (!string.IsNullOrEmpty(customer.CloudPublicId))
                {
                    await _cloudinaryManager.DeleteImageAsync(customer.CloudPublicId);
                }
                var uploadResult = await _cloudinaryManager.UploadImageAsync(file, "CustomerProfiles");

                customer.ImageUrl = uploadResult.ImageUrl;
                customer.CloudPublicId = uploadResult.CloudPublicId;

                await _unitOfWork.Customers.Update(customer);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return ApiResponse<string>.Success(uploadResult.ImageUrl, "Profile picture updated successfully");
                }
                else
                {
                    return ApiResponse<string>.Fail("Failed to save image info to database", ResponseType.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail($"Error: {ex.Message}", ResponseType.InternalServerError);
            }
        }
    }
}

