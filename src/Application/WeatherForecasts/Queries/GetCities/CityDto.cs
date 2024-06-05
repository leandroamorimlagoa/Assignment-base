using Assignment.Domain.Entities;

namespace Assignment.Application.WeatherForecasts.Queries.GetCities;
public class CityDto
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<City, CityDto>();
        }
    }
}
