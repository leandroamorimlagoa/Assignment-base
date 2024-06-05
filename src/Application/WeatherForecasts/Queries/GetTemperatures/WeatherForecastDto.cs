
namespace Assignment.Application.WeatherForecasts.Queries.GetTemperatures;
public class WeatherForecastDto
{
    public int TemperatureC { get; set; }
    public DateTime DateTimeUtc { get; internal set; }
}
