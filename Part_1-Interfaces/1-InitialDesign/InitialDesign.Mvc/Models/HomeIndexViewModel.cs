using InitialDesign.OpenWeatherApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitialDesign.Mvc.Models
{
    public class HomeIndexViewModel
    {

        public String ZipCode { get; set; }

        public OpenWeatherApiResponse WeatherData { get; set; }



    }
}
