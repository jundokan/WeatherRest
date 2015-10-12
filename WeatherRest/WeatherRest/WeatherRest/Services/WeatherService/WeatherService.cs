namespace WeatherRest.Services.WeatherService
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using WeatherRest.Services.Networking;
    using WeatherRest.Models;

    class WeatherService : IWeatherService
    {
        public enum Days
        {
            Today = 0,
            Tomorrow = 7,
            DayAfterTomorrow = 14,
            DayAfterAfterTomorrow = 21
        }

        const string GetForecastUI = "http://api.openweathermap.org/data/2.5/forecast?q=";
        private const string Key = "cccabab2ceb75b93a0c542fb385ae97b";
        readonly IRestClient _restClient = new RestClient();


        public async Task<Forecast> GetForecastForToday(string city)
        {
            var forecastResponce = await ReturnResponce(city);
            return Get(forecastResponce, Days.Today);
        }

        public async Task<Forecast> GetForecastForTomorrow(string city)
        {
            var forecastResponce = await ReturnResponce(city);
            return Get(forecastResponce, Days.Tomorrow);
        }

        public async Task<Forecast> GetForecastForTheDayAfterTomorrow(string city)
        {
            var forecastResponce = await ReturnResponce(city);
            return Get(forecastResponce, Days.DayAfterTomorrow);
        }

        public async Task<Forecast> GetForecastForTheDayAfterAfterTomorrow(string city)
        {
            var forecastResponce = await ReturnResponce(city);
            return Get(forecastResponce, Days.DayAfterAfterTomorrow);
        }

        public async Task<ForecastResponce> ReturnResponce(string city)
        {
            var uri = GetForecastUI + city;
            var responce = await _restClient.GetAsync(uri, Key);
            return JsonConvert.DeserializeObject<ForecastResponce>(responce);
        }

        public static Forecast Get(ForecastResponce fr, Days day)
        {

            return new Forecast
            {
                Humidity = fr.list[(int)(day)].Main.humidity,
                Temperature = Math.Round(fr.list[(int)(day)].Main.temp - 273)
            };
        }
    }
}
