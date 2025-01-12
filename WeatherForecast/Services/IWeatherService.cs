namespace WeatherForecast.Services
{
    public interface IWeatherService
    {
        public Task<CurrentWeatherModel> GetCurrentWeather(double latitude, double longitude);
    }
}
