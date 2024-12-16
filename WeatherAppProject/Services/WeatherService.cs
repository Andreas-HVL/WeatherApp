using WeatherAppProject.Components;
using WeatherAppProject.Model;
using System.Text.Json;
using System.Threading.Tasks;
namespace WeatherAppProject.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpclient;
        private const string ApiKey = "5f547e530c9e01e06ac39e2efeab164c";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5";

        public WeatherService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }
        
        public async Task<CurrentWeather> GetWeatherAsync(string city)
        {
            var url = $"{BaseUrl}/weather?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpclient.GetStringAsync(url);
            Console.WriteLine("raw forecast response:" + response);
            return JsonSerializer.Deserialize<CurrentWeather>(response);

        }

        public async Task<ForecastWeather> GetWeatherForecastAsync(string city)
        {
            var url = $"{BaseUrl}/forecast?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpclient.GetStringAsync(url);
            Console.WriteLine(response);
            return JsonSerializer.Deserialize<ForecastWeather>(response);
        }
    }
}
