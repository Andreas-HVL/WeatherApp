using WeatherAppProject.Components;
using WeatherAppProject.Model;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
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
            var response = await _httpclient.GetFromJsonAsync<CurrentWeather>(url);
            Console.WriteLine("raw forecast response:" + response);
            return response;

        }
        public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string cityName)
        {
            var url = $"https://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=1&appid={ApiKey}";
            var response = await _httpclient.GetFromJsonAsync<List<GeoLocationResponse>>(url);

            if (response != null && response.Count > 0)
            {
                return (response[0].Lat, response[0].Lon);
            }

            throw new Exception("Unable to fetch coordinates for the given city.");
        }

        public async Task<double> GetUVIndexAsync(double latitude, double longitude)
        {
            var url = $"https://api.openweathermap.org/data/2.5/uvi?lat={latitude}&lon={longitude}&appid={ApiKey}";
            var response = await _httpclient.GetFromJsonAsync<UVIndexResponse>(url);

            return response?.Value ?? 0.0;
        }


        public async Task<ForecastWeather> GetWeatherForecastAsync(string city)
        {
            var url = $"{BaseUrl}/forecast?q={city}&appid={ApiKey}&units=metric";
            var response = await _httpclient.GetStringAsync(url);
            Console.WriteLine(response);
            return JsonSerializer.Deserialize<ForecastWeather>(response);
        }
    }

    public class UVIndexResponse
    {
        public double Value { get; set; } // UV Index value
    }

    public class GeoLocationResponse
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
