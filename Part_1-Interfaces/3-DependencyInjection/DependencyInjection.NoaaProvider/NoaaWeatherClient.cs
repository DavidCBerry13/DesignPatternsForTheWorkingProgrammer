using DependencyInjection.WeatherProvider;
using DependencyInjection.ZipCodeService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace DependencyInjection.NoaaProvider
{
    public class NoaaWeatherClient : IWeatherClient
    {


        public NoaaWeatherClient(IZipCodeService zipCodeService)
        {
            ZipCodeService = zipCodeService;
        }


        private IZipCodeService ZipCodeService { get; set; }

       

        public WeatherData GetWeather(string zipCode)
        {
            var zipCodeInfo = ZipCodeService.GetZipCode(zipCode);

            var latitude = zipCodeInfo.Latitude;
            var longitude = zipCodeInfo.Longitude;

            String uri = $"http://forecast.weather.gov/MapClick.php?lat={latitude}&lon={longitude}&FcstType=json";

            HttpClient httpClient = new HttpClient();
            // If you don't have a user agent, NOAA gives you a 403 error
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36");
            String responseJson = httpClient.GetStringAsync(uri).Result;

            NoaaResponse response = JsonConvert.DeserializeObject<NoaaResponse>(responseJson);
            WeatherData weatherData = MapResponse(response);

            return weatherData;
        }

        private WeatherData MapResponse(NoaaResponse response)
        {
            WeatherData data = new WeatherData()
            {
                DataProvider = "NOAA/National Weather Service",
                Location = response.location.areaDescription,
                ObservationTime = DateTime.ParseExact(response.currentobservation.Date.Substring(0, 15), "dd MMM HH:mm tt", CultureInfo.InvariantCulture),
                CurrentConditions = response.currentobservation.Weather,
                Temperature = (Convert.ToDouble(response.currentobservation.Temp) - 32) * 5.0 / 9.0,
                Humidity = Convert.ToDouble(response.currentobservation.Relh),
                Pressure = (response.currentobservation.Altimeter != "NA") ? Convert.ToDouble(response.currentobservation.Altimeter) : (double?)null,
                WindSpeed = (response.currentobservation.Winds != "NA") ? Convert.ToDouble(response.currentobservation.Winds) * 1.609 : (double?)null,
                WindDirection = (response.currentobservation.Windd != "NA") ? CompassDirection.Decode(Convert.ToDouble(response.currentobservation.Windd)) : null,
                WindDirectionDegrees = (response.currentobservation.Windd != "NA") ? Convert.ToDouble(response.currentobservation.Windd) : (double?)null,
            };
            return data;
        }
    }
}

