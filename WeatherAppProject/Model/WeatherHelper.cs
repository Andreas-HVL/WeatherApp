namespace WeatherAppProject.Model
{
    public class WeatherHelper
    {
        public static string GetCityTime(int timezoneOffset)
        {
            var cityTime = DateTime.UtcNow.AddSeconds(timezoneOffset);
            return cityTime.ToString("HH:mm");

        }
        
        public static string GetSunriseTime(long sunriseTimestamp, int timezoneOffset)
        {
            return DateTimeOffset
                .FromUnixTimeSeconds(sunriseTimestamp)
                .ToOffset(TimeSpan.FromSeconds(timezoneOffset))
                .ToString("HH:mm");
        }

        public static string GetSunsetTime(long sunsetTimestamp, int timezoneOffset)
        {
            return DateTimeOffset
               .FromUnixTimeSeconds(sunsetTimestamp)
               .ToOffset(TimeSpan.FromSeconds(timezoneOffset))
               .ToString("HH:mm");
        }

        public static bool IsNight(int timezoneOffset, long sunriseTimestamp, long sunsetTimestamp)
        {
            var cityTime = DateTime.UtcNow.AddSeconds(timezoneOffset);
            var sunrise = DateTimeOffset.FromUnixTimeSeconds(sunriseTimestamp).AddSeconds(timezoneOffset);
            var sunset = DateTimeOffset.FromUnixTimeSeconds(sunsetTimestamp).AddSeconds(timezoneOffset);

            return cityTime < sunrise || cityTime >= sunset;
        }

        public static string GetBackgroundStyle(string weatherCondition, int timezoneOffset, long sunriseTimestamp, long sunsetTimestamp)
        {
            // Adjust city-specific time
            var cityTime = DateTime.UtcNow.AddSeconds(timezoneOffset);
            bool isNight = IsNight(timezoneOffset, sunriseTimestamp, sunsetTimestamp);

            if (isNight)
            {
                return "background-color: #222; color: white;";
            }
            else
            {
                
                var normalizedCondition = weatherCondition?.ToLower().Trim();

                return normalizedCondition switch
                {
                    "clear sky" or "sunny" => "background-color: #87CEEB; color: #000;",
                    "few clouds" => "background-color: #B0E0E6; color: #000;",
                    "scattered clouds" => "background-color: #D3D3D3; color: #000;",
                    "broken clouds" or "cloudy" => "background-color: #A9A9A9; color: #000;",
                    "overcast clouds" => "background-color: #808080; color: #FFF;",
                    "shower rain" or "rain" => "background-color: #4682B4; color: white;",
                    "light rain" => "background-color: #A4B0BE; color: white;",
                    "thunderstorm" => "background-color: #2F4F4F; color: white;",
                    "snow" => "background-color: #FFFACD; color: #000;",
                    "mist" or "fog" => "background-color: #C0C0C0; color: #000;",
                    _ => "background-color: #F0F8FF; color: #000;"
                };

            }
            
        }
    }
}
