using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.LocationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class CityToGetCityDto
    {
        public static List<GetCityDto> Map(this List<City> cities)
        {
            if(cities.Count==0)
                return new List<GetCityDto>();

            return cities.Select(cities => new GetCityDto(cities.CityId, cities.ProvinceId, cities.CityName)).ToList();
        }
    }
}
