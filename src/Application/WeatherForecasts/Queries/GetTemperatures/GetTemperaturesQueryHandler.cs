using Assignment.Application.Common.Interfaces;
using Assignment.Application.WeatherForecasts.Queries.GetCities;
using Assignment.Application.WeatherForecasts.Queries.GetTemperatures;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;
public class GetTemperaturesQueryHandler : IRequestHandler<GetTemperaturesQuery, WeatherForecastDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTemperaturesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<WeatherForecastDto> Handle(GetTemperaturesQuery request, CancellationToken cancellationToken)
    {
        var minTemperature = 0;
        var maxTemperature = 40;
        var temperatureC = new Random().Next(minTemperature, maxTemperature);

        var result = new WeatherForecastDto
        {
            DateTimeUtc = DateTime.UtcNow,
            TemperatureC = temperatureC
        };
        return Task.FromResult(result);
    }
}
