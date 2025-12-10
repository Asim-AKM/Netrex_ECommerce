using Application_Service.DTO_s.UserManagmentDto_s;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Common.Mappers.CustomesrMapper
{
    public static class CustomerMap
    {
        public static Customer Map(this CreateCustomerDto createCustomerDto)
        {
            return new Customer
            {
                CustomerId = new Guid(),
                UserId = new Guid(),
                City  = createCustomerDto.City,
                Province = createCustomerDto.Province,
                Country = createCustomerDto.Country,
                Address = createCustomerDto.Address,
            };

        }
    }
}

