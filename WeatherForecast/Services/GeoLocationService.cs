using Microsoft.AspNetCore.DataProtection.KeyManagement;
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

        public async Task<GeoLocationsViewModel> GetLocations(string? name)
        {
            string? endPoint = _configuration["geoLocationEndPoint"];

            if (string.IsNullOrEmpty(endPoint))
            {
                throw new InvalidProgramException("Geo location api endpoint not configured properly");
            }
            GeoLocationsViewModel? geoLocations;
            try
            {
                string finalUrl = $"{endPoint}name={name}&count=10&language=en&format=json";
                HttpResponseMessage? response = await _httpClient.GetAsync(finalUrl);


                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    geoLocations = JsonSerializer.Deserialize<GeoLocationsViewModel>(result);
                    if (geoLocations == null)
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
            return geoLocations;
        }
    }
}
