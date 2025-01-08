using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.ViewModel;

namespace WeatherForecast.Controllers
{
    public class WeatherController : Controller
    {

        public IActionResult Index()
        {
            Forecast Today = new Forecast()
            {
                CityName = "Noida",
                Temperature = 19,
                WeekDay = DateTime.Now.DayOfWeek.ToString(),
                WeatherType = WeatherTypeEnum.Rainy
            };

            List<Forecast> forecasts = new List<Forecast>();

            for (int i = 1; i <= 5; i++)
            {
                forecasts.Add(new Forecast()
                {
                    CityName = "Noida",
                    Temperature = Random.Shared.Next(10, 20),
                    WeekDay = DateTime.Now.AddDays(i).DayOfWeek.ToString(),
                    WeatherType = WeatherTypeEnum.Rainy
                });
            }

            ForecastViewModel forecastData = new ForecastViewModel();
            forecastData.ForecastList = forecasts;
            forecastData.TodayWeather = Today;

            return View(forecastData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
