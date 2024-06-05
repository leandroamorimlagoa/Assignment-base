using Assignment.Application.Common.Security;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;

[Authorize]
public record GetCountriesQuery : IRequest<IList<CountryDto>>;
