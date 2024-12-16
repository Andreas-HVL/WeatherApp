using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherAppProject.Model
{
    public class DailyForecast
    {
        public DateTime Date { get; set; } // Date of the forecast
        public string DayName { get; set; } // Day of the week, e.g., Monday
        public int Temp { get; set; } // Representative temperature
        public string Condition { get; set; } // Weather condition
        public int TempMax { get; set; }
        public int TempMin { get; set; }
        public  double ChanceOfRain { get; set; }
        public List<HourlyForecast> HourlyForecasts { get; set; } // 3-hour forecasts
        public string Icon { get; set; }
        [JsonPropertyName("pop")]
        public double Pop { get; set; } // Probability of precipitation (0.0 - 1.0)
        [JsonPropertyName("dt_txt")]
        public string dt { get; set; }

    }
}
