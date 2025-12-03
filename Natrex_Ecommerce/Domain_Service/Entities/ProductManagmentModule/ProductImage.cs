using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Entities.ProductAndCategoryModule
{
    public class ProductImage
    {
        public Guid ImageId { get; set; }
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public DateTime UploadedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

    }
}
