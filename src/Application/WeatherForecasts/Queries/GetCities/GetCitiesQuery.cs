using Assignment.Application.Common.Security;
using Assignment.Application.WeatherForecasts.Queries.GetCities;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;

[Authorize]
public record GetCitiesQuery : IRequest<IList<CityDto>>
{
    public int CountryId { get; set; }
}
