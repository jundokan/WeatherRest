namespace WeatherRest.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using WeatherRest.Services.WeatherService;
    using Xamarin.Forms;

    class WeatherContentViewModel : INotifyPropertyChanged
    {
        private readonly IWeatherService _ws;
        private string _cityName;
        private string _currentDate;
        private string _dayAfterAfterTomorrowDate;
        private string _dayAfterTomorrowDate;
        private string _humidity;
        private string _humidityAfterAfterTomorrow;
        private string _humidityAfterTomorrow;
        private string _humidityTomorrow;
        private string _temperature;
        private string _temperatureAfterAfterTomorrow;
        private string _temperatureAfterTomorrow;
        private string _temperatureTomorrow;
        private string _tomorrowDate;

        public WeatherContentViewModel()
        {
            _ws = new WeatherService();
            SearchCommand = new Command(Search);
            var now = DateTime.Now;
            CurrentDate = DateTime.Today.ToString("M");
            TomorrowDate = now.AddDays(1).ToString("dd-MM-yy");
            DayAfterTomorrowDate = now.AddDays(2).ToString("dd-MM-yy");
            DayAfterAfterTomorrowDate = now.AddDays(3).ToString("dd-MM-yy");
        }

        public ICommand SearchCommand { get; private set; }

        public string CityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                _cityName = value;
            }
        }

        public string CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                OnPropertyChanged();
            }
        }

        public string Humidity
        {
            get
            {
                return _humidity;
            }
            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        public string Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }

        public string TomorrowDate
        {
            get
            {
                return _tomorrowDate;
            }
            set
            {
                _tomorrowDate = value;
                OnPropertyChanged();
            }
        }

        public string DayAfterTomorrowDate
        {
            get
            {
                return _dayAfterTomorrowDate;
            }
            set
            {
                _dayAfterTomorrowDate = value;
                OnPropertyChanged();
            }
        }

        public string DayAfterAfterTomorrowDate
        {
            get
            {
                return _dayAfterAfterTomorrowDate;
            }
            set
            {
                _dayAfterAfterTomorrowDate = value;
                OnPropertyChanged();
            }
        }

        public string HumidityTomorrow
        {
            get
            {
                return _humidityTomorrow;
            }
            set
            {
                _humidityTomorrow = value;
                OnPropertyChanged();
            }
        }

        public string HumidityAfterTomorrow
        {
            get
            {
                return _humidityAfterTomorrow;
            }
            set
            {
                _humidityAfterTomorrow = value;
                OnPropertyChanged();
            }
        }

        public string HumidityAfterAfterTomorrow
        {
            get
            {
                return _humidityAfterAfterTomorrow;
            }
            set
            {
                _humidityAfterAfterTomorrow = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureTomorrow
        {
            get
            {
                return _temperatureTomorrow;
            }
            set
            {
                _temperatureTomorrow = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureAfterTomorrow
        {
            get
            {
                return _temperatureAfterTomorrow;
            }
            set
            {
                _temperatureAfterTomorrow = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureAfterAfterTomorrow
        {
            get
            {
                return _temperatureAfterAfterTomorrow;
            }
            set
            {
                _temperatureAfterAfterTomorrow = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        async void Search()
        {
            if (!IsCityNameValid(CityName))
                return;
            var forecastToday = await _ws.GetForecastForToday(CityName);
            Temperature = forecastToday.Temperature.ToString();
            Humidity = forecastToday.Humidity.ToString();

            var forecastForTomorrow = await _ws.GetForecastForTomorrow(CityName);
            TemperatureTomorrow = forecastForTomorrow.Temperature.ToString();
            HumidityTomorrow = forecastForTomorrow.Humidity.ToString();

            var forecastForDayAfterTomorrow = await _ws.GetForecastForTheDayAfterTomorrow(CityName);
            TemperatureAfterTomorrow = forecastForDayAfterTomorrow.Temperature.ToString();
            HumidityAfterTomorrow = forecastForDayAfterTomorrow.Humidity.ToString();

            var forecastForDayAfterAfterTomorrow = await _ws.GetForecastForTheDayAfterAfterTomorrow(CityName);
            TemperatureAfterAfterTomorrow = forecastForDayAfterAfterTomorrow.Temperature.ToString();
            HumidityAfterAfterTomorrow = forecastForDayAfterAfterTomorrow.Humidity.ToString();
        }

        private bool IsCityNameValid(string cityName)
        {
            return Regex.IsMatch(cityName, @"^[^0-9\#\$\@\+]*$");
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
