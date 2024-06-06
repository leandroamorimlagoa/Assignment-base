using Assignment.Application.Common.Interfaces;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;
public class GetTemperaturesQueryHandler : IRequestHandler<GetTemperaturesQuery, int>
{
    private readonly IWeatherForecastApi _weatherForecastApi;

    public GetTemperaturesQueryHandler(IWeatherForecastApi weatherForecastApi)
    {
        _weatherForecastApi = weatherForecastApi;
    }

    public Task<int> Handle(GetTemperaturesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_weatherForecastApi.GetTemperature(request.CityName, request.DateTimeUtc));
    }
}
