using Assignment.Application.WeatherForecasts.Queries.GetCities;
using Assignment.Application.WeatherForecasts.Queries.GetCountries;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI.Features.WeatherForecasts;
public class WeatherForecastViewModel : Screen
{
    private readonly ISender _sender;

    private IList<CountryDto> _countries;
    public IList<CountryDto> Countries
    {
        get => _countries;
        set
        {
            _countries = value;
            NotifyOfPropertyChange(() => Countries);
        }
    }

    private IList<CityDto> _cities;
    public IList<CityDto> Cities
    {
        get => _cities;
        set
        {
            _cities = value;
            NotifyOfPropertyChange(() => Cities);
        }
    }

    private CountryDto _selectedCountry;
    public CountryDto SelectedCountry
    {
        get => _selectedCountry;
        set
        {
            _selectedCountry = value;
            NotifyOfPropertyChange(() => SelectedCountry);
            IsCitiesEnabled = value != null && value.Id > 0;
            LoadCities();
        }
    }

    private CityDto _selectedCity;
    public CityDto SelectedCity
    {
        get => _selectedCity;
        set
        {
            _selectedCity = value;
            NotifyOfPropertyChange(() => SelectedCity);
        }
    }

    private bool _isCitiesEnabled;
    public bool IsCitiesEnabled
    {
        get => _isCitiesEnabled;
        set
        {
            _isCitiesEnabled = value;
            NotifyOfPropertyChange(() => IsCitiesEnabled);
        }
    }

    private string _weatherForecastTemperature;
    public string WeatherForecastTemperature
    {
        get => _weatherForecastTemperature;
        set
        {
            _weatherForecastTemperature = value;
            NotifyOfPropertyChange(() => WeatherForecastTemperature);
        }
    }

    public WeatherForecastViewModel(ISender sender)
    {
        _sender = sender;
        Countries = new List<CountryDto>();
        Cities = new List<CityDto>();
        Initialize();
    }

    private async void Initialize()
    {
        Countries = await _sender.Send(new GetCountriesQuery());
    }

    public async void LoadTemperature()
    {
        if (SelectedCity != null)
        {
            var temperatureQuery = new GetTemperaturesQuery
            {
                CityName = SelectedCity.Name,
                DateTimeUtc = DateTime.UtcNow
            };

            var temp = await _sender.Send(temperatureQuery);
            WeatherForecastTemperature = $"{temp}°C";
            return;
        }

        WeatherForecastTemperature = string.Empty;
    }

    public async void Close()
    {
        await TryCloseAsync();
    }

    private async void LoadCities()
    {
        if (SelectedCountry != null)
        {
            Cities = await _sender.Send(new GetCitiesQuery { CountryId = SelectedCountry.Id });
        }
    }
}

