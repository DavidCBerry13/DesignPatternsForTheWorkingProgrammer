using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.WeatherProvider
{
    public class WeatherData
    {

        public String DataProvider { get; set; }
        public DateTime ObservationTime { get; set; }


        public String CurrentConditions { get; set; }

        public String Location { get; set; }

        public double Temperature { get; set; }

        public double? Humidity { get; set; }

        public double? Pressure { get; set; }

        public double? WindSpeed { get; set; }

        public CompassDirection WindDirection { get; set; }

        public double? WindDirectionDegrees { get; set; }


    }
}
