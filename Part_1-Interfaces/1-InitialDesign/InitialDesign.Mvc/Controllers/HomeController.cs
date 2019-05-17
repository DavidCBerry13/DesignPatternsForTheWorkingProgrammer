using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InitialDesign.Mvc.Models;
using InitialDesign.OpenWeatherApi;

namespace InitialDesign.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(String zipCode = null)
        {
            zipCode = zipCode ?? "60605";

            OpenWeatherApiClient client = new OpenWeatherApiClient();
            var response = client.GetWeather(zipCode);

            var model = new HomeIndexViewModel() { ZipCode = zipCode, WeatherData = response };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
