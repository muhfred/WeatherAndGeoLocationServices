using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAndGeoLocationServices.Models.Weather;

namespace WeatherAndGeoLocationServices.Services
{
    public interface IForecastService
    {
        Task<WeatherResponse> GetForecast(string cityCode);
    }
}
