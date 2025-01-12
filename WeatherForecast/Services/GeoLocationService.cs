using WeatherForecast.ViewModel;

namespace WeatherForecast.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<GeoLocationsViewModel> GetLocations(string name)
        {
            string endPoint = "https://geocoding-api.open-meteo.com/v1/search?";
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
