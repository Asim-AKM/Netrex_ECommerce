namespace Application_Service.DTO_s.UserManagmentDto_s
{
    public  record UpdateUserDto(Guid Id,string? FullName,string? ImageUrl,string? UserName,string? Email,string? Contact,string City,string Province,string Country,string Address);

}
