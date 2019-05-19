using Decorator.WeatherProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decorator.Mvc.Models
{
    public class HomeIndexViewModel
    {
        public String ZipCode { get; set; }

        public WeatherData WeatherData { get; set; }

    }
}
