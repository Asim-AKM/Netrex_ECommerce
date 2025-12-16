namespace Application_Service.DTO_s.UserManagmentDto_s
{
    public record GetCustomerDto(Guid CustomerId, Guid UserId, string City, string Province, string Country, string Address);

}
