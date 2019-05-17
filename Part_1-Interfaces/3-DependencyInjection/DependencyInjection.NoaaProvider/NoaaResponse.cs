using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.NoaaProvider
{
    internal class NoaaResponse
    {
        public string operationalMode { get; set; }
        public string srsName { get; set; }
        public string creationDate { get; set; }
        public string creationDateLocal { get; set; }
        public string productionCenter { get; set; }
        public string credit { get; set; }
        public string moreInformation { get; set; }
        public Location location { get; set; }
        public ForecastTimes time { get; set; }
        public ForecastData data { get; set; }
        public CurrentObservation currentobservation { get; set; }

        internal class Location
        {
            public string region { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
            public string wfo { get; set; }
            public string timezone { get; set; }
            public string areaDescription { get; set; }
            public string radar { get; set; }
            public string zone { get; set; }
            public string county { get; set; }
            public string firezone { get; set; }
            public string metar { get; set; }
        }

        internal class ForecastTimes
        {
            public string layoutKey { get; set; }
            public List<string> startPeriodName { get; set; }
            public List<string> startValidTime { get; set; }
            public List<string> tempLabel { get; set; }
        }

        internal class ForecastData
        {
            public List<string> temperature { get; set; }
            public List<string> pop { get; set; }
            public List<string> weather { get; set; }
            public List<string> iconLink { get; set; }
            public List<object> hazard { get; set; }
            public List<object> hazardUrl { get; set; }
            public List<string> text { get; set; }
        }


        internal class CurrentObservation
        {
            public string id { get; set; }
            public string name { get; set; }
            public string elev { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string Date { get; set; }
            public string Temp { get; set; }
            public string Dewp { get; set; }
            public string Relh { get; set; }
            public string Winds { get; set; }
            public string Windd { get; set; }
            public string Gust { get; set; }
            public string Weather { get; set; }
            public string Weatherimage { get; set; }
            public string Visibility { get; set; }
            public string Altimeter { get; set; }
            public string SLP { get; set; }
            public string timezone { get; set; }
            public string state { get; set; }
            public string WindChill { get; set; }
        }
    }
}
