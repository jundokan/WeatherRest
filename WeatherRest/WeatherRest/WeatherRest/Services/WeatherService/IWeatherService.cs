namespace WeatherRest.Services.WeatherService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using WeatherRest.Models;

    interface IWeatherService
    {
        Task<Forecast> GetForecastForToday(string city);
        Task<Forecast> GetForecastForTomorrow(string city);
        Task<Forecast> GetForecastForTheDayAfterTomorrow(string city);
        Task<Forecast> GetForecastForTheDayAfterAfterTomorrow(string city);
    }
}
