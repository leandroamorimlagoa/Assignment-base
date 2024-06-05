using Assignment.Application.Common.Security;
using Assignment.Application.WeatherForecasts.Queries.GetTemperatures;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;

[Authorize]
public record GetTemperaturesQuery : IRequest<WeatherForecastDto>
{
    public int CityId { get; set; }
}
