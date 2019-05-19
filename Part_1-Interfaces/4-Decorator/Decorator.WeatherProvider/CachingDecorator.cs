using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.WeatherProvider
{
    public class CachingDecorator : IWeatherClient
    {

        public CachingDecorator(IWeatherClient client, IMemoryCache cache)
        {
            DecoratedWeatherClient = client;
            WeatherResultsCache = cache;
        }


        private IWeatherClient DecoratedWeatherClient { get; set; }

        private IMemoryCache WeatherResultsCache { get; set; }


        public WeatherData GetWeather(string zipCode)
        {
            string cacheKey = $"{this.GetType().Name}-{zipCode}";
            WeatherData weatherData = null;

            // Look for cache key.
            if (!WeatherResultsCache.TryGetValue(cacheKey, out weatherData))
            {
                // Zip Code not in cache, so get 
                weatherData = DecoratedWeatherClient.GetWeather(zipCode);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(600));

                // Save data in cache.
                WeatherResultsCache.Set(cacheKey, weatherData, cacheEntryOptions);
            }

            return weatherData;
        }
    }
}
