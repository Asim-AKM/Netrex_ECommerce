using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.LocationModules
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; }
        public Guid ProvinceId { get; set; }
        public string CityName { get; set; } = string.Empty;
    }
}
