using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.ProductAndCategoryModule
{
    public class ProductCategory
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
