using WeatherForecast.Models;

namespace WeatherForecast.ViewModel
{
    public class ForecastViewModel
    {
        public Forecast TodayWeather { get; set; }
        public List<Forecast> ForecastList { get; set; }
    }
}
