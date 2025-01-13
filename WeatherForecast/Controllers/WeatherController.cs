using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Controllers
{
    public class WeatherController : Controller
    {

        private IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCurrentWeather(double? latitude, double? longitude)
        {

            //return StatusCode(400, new { message = "you gave wrong coordinates" });

            CurrentWeatherModel result;
            try
            {
                if (latitude == null)
                {
                    throw new ArgumentNullException(nameof(latitude), "latitude was not provided");
                }
                if (longitude == null)
                {
                    throw new ArgumentNullException(nameof(longitude), "longitude was not provided");
                }

                result = await _weatherService.GetCurrentWeather((double)latitude, (double)longitude);
                return PartialView("/Views/Partial/_WeatherWidgetPartial.cshtml", result);

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
