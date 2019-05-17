using System;

namespace Interfaces.WeatherProvider
{
    public interface IWeatherClient
    {

        WeatherData GetWeather(String zipCode);

    }
}
