namespace WeatherAppProject.Model
{
    public class WeatherResponse
    {
        public Coord Coord { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public string Name { get; set; }
    }
    
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }

    }

    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }

}
