using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.UserManagmentModule
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;


    }
}
