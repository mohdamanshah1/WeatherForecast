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
            //return StatusCode(400, new { message = "you gave wrong name" });
            GeoLocationsViewModel result;
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException(nameof(name), "no name provided");
                }

                result = await _geoLocationService.GetLocations(name);
                return PartialView("/Views/Partial/_CityListPartial.cshtml", result);
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            catch (JsonException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
