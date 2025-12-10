using Application_Service.Common.Mappers.CustomesrMapper;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class CustomerManager : ICustomermanager
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> DeleteCustomer(Guid customerId)
        {
            // request to Sir : If we place the GetById logic directly inside the Delete function
            // (used in the repository Directly), the manager code will remain much cleaner.
            var data = await _unitOfWork.Customers.GetById(customerId);
            await _unitOfWork.Customers.Delete(data);
            var user = await _unitOfWork.Users.GetById(data.UserId);
            await _unitOfWork.Users.Delete(user);
            var userCred = await _unitOfWork.UserCreads.GetById(user.UserId);
            await _unitOfWork.UserCreads.Delete(userCred);
            var userRole = await _unitOfWork.UserRoles.GetById(user.UserId);
            await _unitOfWork.UserRoles.Delete(userRole);
            await _unitOfWork.SaveChangesAsync();

            return "Customer Deleted Successfully";

        }

        public Task<Customer> GetAllCustomer(Guid customerId)
        {
            // The work is currently on hold as I need to discuss
            // the implementation details on Microsoft Teams.
            throw new NotImplementedException();
        }

        public async Task<string> UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            var data = await _unitOfWork.Customers.GetById(updateCustomer.CustomerId);
            data.Province = updateCustomer.Province;
            data.City = updateCustomer.City;
            data.Country = updateCustomer.Country;
            data.Address = updateCustomer.Address;
            await _unitOfWork.Customers.Update(data);
            await _unitOfWork.SaveChangesAsync();

            return "Customer Updated Successfully";
        }

    }
}

