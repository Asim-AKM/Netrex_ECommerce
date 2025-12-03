using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }
        public Guid CustomerId { get; set; }

    }
}
