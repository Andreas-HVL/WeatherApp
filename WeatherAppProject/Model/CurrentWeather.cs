using System.Text.Json.Serialization;
namespace WeatherAppProject.Model
{
    public class CurrentWeather
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        public string Time {  get; set; }

        [JsonPropertyName("dt_txt")]
        public string dt { get; set; }

        [JsonPropertyName("pop")]
        public double Pop { get; set; } // Probability of precipitation (0.0 - 1.0)

        public Sys Sys { get; set; }

        public Wind Wind { get; set; }

    }

    public class Sys
    {
        public long Sunrise { get; set; } // Unix timestamp for sunrise
        public long Sunset { get; set; }  // Unix timestamp for sunset
    }


    public class Main
    {
        [JsonPropertyName("temp")]   
        public double Temp { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        public double TempMax { get; set; }
        public double TempMin { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; } // Wind speed in m/s
        public int Deg { get; set; }      // Wind direction (optional)
    }

    public class Weather
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
            
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

    }
}
        
    
    
