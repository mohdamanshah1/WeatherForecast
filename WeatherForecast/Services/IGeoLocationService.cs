using WeatherForecast.ViewModel;

namespace WeatherForecast.Services
{
    public interface IGeoLocationService
    {
        Task<GeoLocationsViewModel> GetLocations(string name);
    }
}
