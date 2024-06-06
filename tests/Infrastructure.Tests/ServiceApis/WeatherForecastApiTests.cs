using Assignment.Application.Common.Interfaces;
using Assignment.Infrastructure.ServiceApis;

namespace Infrastructure.Tests.ServiceApis;
[TestFixture]
public class WeatherForecastApiTests
{
    private IWeatherForecastApi _weatherForecastApi;

    [SetUp]
    public void SetUp()
    {
        _weatherForecastApi = new WeatherForecastApi();
    }

    [Test]
    [Repeat(100)]
    public void GetTemperature_ShouldReturnTemperatureWithinRange_WhenCalledMultipleTimes()
    {
        // Arrange
        var cityName = "TestCity";
        var time = DateTime.Now;

        // Act
        var temperature = _weatherForecastApi.GetTemperature(cityName, time);

        // Assert
        Assert.That(temperature, Is.InRange(0, 40));
    }
}
