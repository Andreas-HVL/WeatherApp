using System.Text.Json.Serialization;

namespace WeatherAppProject.Model
{
    public class ForecastWeather
    {
        [JsonPropertyName("list")]
        public List<ListItem> List { get; set; }
        public List<CurrentWeather> weatherList { get; set; }
    }

    public class ListItem
    {
        [JsonPropertyName("main")]
        public Main main { get; set; }

        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }

        [JsonPropertyName("dt_txt")]
        public string dt { get; set; }

        [JsonPropertyName("pop")]
        public double Pop { get; set; } // Probability of precipitation (0.0 - 1.0)


    }
    
}
