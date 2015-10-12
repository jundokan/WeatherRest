namespace WeatherRest.Services.Networking
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    interface IRestClient
    {
        Task<string> GetAsync(string uri, string key);
    }
}
