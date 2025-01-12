using System.Diagnostics;
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

        public async Task<IActionResult> GetCurrentWeather(double latitude, double longitude)
        {
            CurrentWeatherModel result = await _weatherService.GetCurrentWeather(latitude, longitude);
            return PartialView("/Views/Partial/_WeatherWidgetPartial.cshtml", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
