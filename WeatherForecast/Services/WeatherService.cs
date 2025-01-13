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
            string? endPoint = _configuration["weatherEndPoint"];

            string? apiKey = _configuration["weatherApiKey"];

            if (string.IsNullOrEmpty(endPoint) || string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("Weather Api key or endpoint not configured properly");
            }

            CurrentWeatherModel? currentWeather;
            try
            {
                string finalUrl = $"{endPoint}q={latitude},{longitude}&key={apiKey}";
                HttpResponseMessage response = await _httpClient.GetAsync(finalUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    currentWeather = JsonSerializer.Deserialize<CurrentWeatherModel>(result);
                    if (currentWeather == null)
                    {
                        throw new JsonException("Could not deserialise the data");
                    }
                }
                else
                {
                    throw new HttpRequestException($"Request Failed: {response.StatusCode}, {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
            catch (JsonException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return currentWeather;
        }
    }
}
