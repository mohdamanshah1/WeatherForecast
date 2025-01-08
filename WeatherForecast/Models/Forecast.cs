namespace WeatherForecast.Models
{
    public class Forecast
    {
        public string CityName { get; set; } = string.Empty;
        public int Temperature { get; set; }
        public string WeekDay { get; set; } = string.Empty;
        public WeatherTypeEnum WeatherType { get; set; }
    }
    
    public enum WeatherTypeEnum
    {
        Rainy,
        Sunny
    }
}
