using Microsoft.AspNetCore.Mvc;


namespace WeatherForecast.Controllers
{
    public class GeoLocationController : Controller
    {

        private IGeoLocationService _geoLocationService;
        public GeoLocationController(IGeoLocationService getLocationService)
        {
            _geoLocationService = getLocationService;
        }

        public async Task<IActionResult> GetPlaces([FromQuery] string? name)
        {
            GeoLocationsViewModel result = await _geoLocationService.GetLocations(name);
            return PartialView("/Views/Partial/_CityListPartial.cshtml",result);
        }
    }
}
