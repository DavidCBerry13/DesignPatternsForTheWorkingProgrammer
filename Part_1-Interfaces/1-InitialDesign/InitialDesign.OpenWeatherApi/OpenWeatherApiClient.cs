using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace InitialDesign.OpenWeatherApi
{

    public class OpenWeatherApiClient
    {
        public static String ApiKey { get; set; }

        public static String Units { get; set; }


        public OpenWeatherApiResponse GetWeather(String zipCode)
        {
            String uri = $"http://api.openweathermap.org/data/2.5/weather?units={Units}&zip={zipCode},us&appid={ApiKey}";

            HttpClient httpClient = new HttpClient();
            String responseJson = httpClient.GetStringAsync(uri).Result;

            OpenWeatherApiResponse response = JsonConvert.DeserializeObject<OpenWeatherApiResponse>(responseJson);
            return response;
        }
    }
}
