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
