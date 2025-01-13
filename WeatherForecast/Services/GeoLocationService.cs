using WeatherForecast.ViewModel;

namespace WeatherForecast.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private IConfiguration _configuration;

        public GeoLocationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GeoLocationsViewModel> GetLocations(string name)
        {
            string endPoint = _configuration["geoLocationEndPoint"];
            GeoLocationsViewModel geoLocations;
            try
            {
                string finalUrl = $"{endPoint}name={name}&count=10&language=en&format=json";
                HttpResponseMessage? response = await _httpClient.GetAsync(finalUrl);
                string result = await response.Content.ReadAsStringAsync();
                geoLocations = JsonSerializer.Deserialize<GeoLocationsViewModel>(result);
            }
            catch (HttpRequestException ex)
            {
                geoLocations = new();
            }
            return geoLocations;
        }
    }
}
