using Assignment.Application.Common.Interfaces;

namespace Assignment.Infrastructure.ServiceApis;
internal class WeatherForecastApi : IWeatherForecastApi
{
    public int GetTemperature(string cityName, DateTime time)
    {
        var minTemperature = 0;
        var maxTemperature = 40;
        return new Random().Next(minTemperature, maxTemperature);
    }
}
