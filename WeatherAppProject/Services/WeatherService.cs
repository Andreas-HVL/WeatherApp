using WeatherAppProject.Components;
using WeatherAppProject.Model;

namespace WeatherAppProject.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpclient;

        public WeatherService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }
        
        public async Task<WeatherResponse> GetWeatherAsync(string city, string apiKey)
        {
            var response = await _httpclient.GetFromJsonAsync<WeatherResponse>($"http://api.openweathermap.org/data/2.5/forecast?id=524901&appid={apiKey}");

            return response;
        }
    }
}
