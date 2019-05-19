using System;

namespace Decorator.WeatherProvider
{
    public interface IWeatherClient
    {

        WeatherData GetWeather(String zipCode);

    }
}
