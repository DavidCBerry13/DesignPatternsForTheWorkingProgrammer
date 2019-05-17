using System;

namespace DependencyInjection.WeatherProvider
{
    public interface IWeatherClient
    {

        WeatherData GetWeather(String zipCode);

    }
}
