using Assignment.Application.Common.Security;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;

[Authorize]
public record GetTemperaturesQuery : IRequest<int>
{
    public string CityName { get; init; } = string.Empty;
    public DateTime DateTimeUtc { get; init; } = DateTime.UtcNow;
}
