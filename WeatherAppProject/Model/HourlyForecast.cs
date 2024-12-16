namespace WeatherAppProject.Model
{
    public class HourlyForecast
    {
        public string Time { get; set; } // Time of the forecast (e.g., 12:00 PM)
        public int Temp { get; set; } // Temperature in int
        public string Condition { get; set; } // Weather description
        public string Icon { get; set; }
    }
}
