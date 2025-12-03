using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    public class CartItem
    {
        [Key]
        public Guid CartItemId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
