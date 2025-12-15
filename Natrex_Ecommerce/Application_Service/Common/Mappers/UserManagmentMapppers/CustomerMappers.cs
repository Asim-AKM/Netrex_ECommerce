using Application_Service.DTO_s.UserManagmentDto_s;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Common.Mappers.UserManagmentMapppers
{
    internal static class CustomerMappers
    {
        public static Customer MapToDomain(this UpdateCustomerDto customerDto)
        {
            return new Customer()
            {
                UserId = customerDto.UserId,
                Country = customerDto.Country,
                Province = customerDto.Province,
                City = customerDto.City,
                Address = customerDto.Address,
            };
        }

        public static List<GetCustomerDto> MapToGetAllDto(this List<Customer> listOfCustomers)
        {
            List<GetCustomerDto> customerDtos = new List<GetCustomerDto>();
            foreach (var customers in listOfCustomers)
            {
                var customerDto = new GetCustomerDto(
                    customers.CustomerId, customers.UserId,
                    customers.City, customers.Province,
                    customers.Country, customers.Address
                    );
                customerDtos.Add(customerDto);
            }
            return customerDtos;

        }
    }
}
