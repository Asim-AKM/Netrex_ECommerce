using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.LocationModules;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class ProvinceToGetAllProvinceDto
    {
        public static List<GetProvinceDto> Map(this List<Province> provinces)
        {
            if(provinces==null||provinces.Count == 0)
                return new List<GetProvinceDto>();

            return provinces.Select(province => new GetProvinceDto(province.ProvinceId, province.ProvinceName)).ToList();

        }
    }
}
