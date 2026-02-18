namespace Domain_Service.Entities.ProductManagmentModule
{
    public class ProductView
    {
        public Guid ProductViewId { get; set; }

        public Guid ProductId { get; set; }

        // Agar user logged in hai toh UserId store karo, warna null rehne do
        public Guid? UserId { get; set; }

        public string IPAddress { get; set; }=string.Empty;

        public DateTime ViewedAt { get; set; }
    }
}
