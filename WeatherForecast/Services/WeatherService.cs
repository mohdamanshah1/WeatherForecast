namespace WeatherForecast.Services
{
    public class WeatherService : IWeatherService
    {
        private IConfiguration _configuration;

        public WeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<CurrentWeatherModel> GetCurrentWeather(double latitude, double longitude)
        {
            string endPoint = _configuration["weatherEndPoint"];

            string? apiKey = _configuration["weatherApiKey"];

            CurrentWeatherModel currentWeather;
            try
            {
                string finalUrl = $"{endPoint}q={latitude},{longitude}&key={apiKey}";
                HttpResponseMessage response = await _httpClient.GetAsync(finalUrl);
                string result = await response.Content.ReadAsStringAsync();
                currentWeather = JsonSerializer.Deserialize<CurrentWeatherModel>(result);
            }
            catch (Exception ex)
            {
                currentWeather = new();
            }
            return currentWeather;
        }
    }
}
