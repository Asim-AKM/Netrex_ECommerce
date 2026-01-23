using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.LocationModules
{
    public class Province
    {
        [Key]
        public Guid ProvinceId { get; set; }
        public string ProvinceName { get; set; } = string.Empty;
    }
}
