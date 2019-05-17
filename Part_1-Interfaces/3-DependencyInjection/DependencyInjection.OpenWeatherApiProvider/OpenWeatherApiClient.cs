using DependencyInjection.WeatherProvider;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;

namespace DependencyInjection.OpenWeatherApiProvider
{
    public class OpenWeatherApiClient : IWeatherClient
    {

        public OpenWeatherApiClient(String apiKey, String units)
        {
            ApiKey = apiKey;
            Units = units;
        }

        private String ApiKey { get; set; }

        private String Units { get; set; }


        public WeatherData GetWeather(string zipCode)
        {
            String uri = $"http://api.openweathermap.org/data/2.5/weather?units={Units}&zip={zipCode},us&appid={ApiKey}";

            HttpClient httpClient = new HttpClient();
            String responseJson = httpClient.GetStringAsync(uri).Result;

            OpenWeatherApiResponse response = JsonConvert.DeserializeObject<OpenWeatherApiResponse>(responseJson);
            WeatherData weatherData = MapResponse(response);

            return weatherData;
        }



        internal WeatherData MapResponse(OpenWeatherApiResponse response)
        {
            WeatherData weatherData = new WeatherData()
            {
                DataProvider = "Open Weather API",
                ObservationTime = DateTimeOffset.FromUnixTimeMilliseconds(response.dt).UtcDateTime,
                Location = response.name,
                CurrentConditions = response.weather.FirstOrDefault()?.main,
                Temperature = response.main.temp,
                Humidity = response.main.humidity,
                Pressure = response.main.pressure,
                WindSpeed = response.wind.speed,
                WindDirection = response.wind.deg
            };

            return weatherData;
        }




    }
}
