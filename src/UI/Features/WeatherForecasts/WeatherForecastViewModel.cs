using System.Collections.ObjectModel;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.Application.WeatherForecasts.Queries.GetCities;
using Assignment.Application.WeatherForecasts.Queries.GetCountries;
using Assignment.Application.WeatherForecasts.Queries.GetTemperatures;
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
            CanLoadTemperature = value != null && value.Id > 0;
        }
    }

    private bool _canLoadTemperature;
    public bool CanLoadTemperature
    {
        get => _canLoadTemperature;
        set
        {
            _canLoadTemperature = value;
            NotifyOfPropertyChange(() => CanLoadTemperature);
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

    private WeatherForecastDto _weatherForecast;
    public WeatherForecastDto WeatherForecast
    {
        get => _weatherForecast;
        set
        {
            _weatherForecast = value;
            NotifyOfPropertyChange(() => WeatherForecast);
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
            WeatherForecast = await _sender.Send(new GetTemperaturesQuery { CityId = SelectedCity.Id });
        }
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

