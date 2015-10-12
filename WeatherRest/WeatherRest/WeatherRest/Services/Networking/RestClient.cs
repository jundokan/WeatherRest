namespace WeatherRest.Services.Networking
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    class RestClient : IRestClient
    {
        public async Task<string> GetAsync(string uri, string Key)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(uri);
            var responce = await httpClient.GetAsync(string.Format("{0}&appid={1}", uri, Key));
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();
            return content;
        }
    }
}
