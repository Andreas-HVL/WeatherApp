using System.Text.Json.Serialization;

namespace WeatherAppProject.Model
{
    public class ForecastWeather
    {
        [JsonPropertyName("list")]
        public List<ListItem> List { get; set; }
    }

    public class ListItem
    {
        [JsonPropertyName("main")]
        public Main main { get; set; }

        [JsonPropertyName("weather")]
        public Weather[] weather { get; set; }

        [JsonPropertyName("dt_txt")]
        public string Dt_txt { get; set; }
    }
    
}
