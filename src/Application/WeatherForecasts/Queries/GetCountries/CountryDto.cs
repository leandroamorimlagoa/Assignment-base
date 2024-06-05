using Assignment.Domain.Entities;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;
public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
