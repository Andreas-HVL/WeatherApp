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

    }

    public class Main
    {
        [JsonPropertyName("temp")]   
        public double Temp { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
    public class Weather
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
            
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

    }
}
        
    
    
