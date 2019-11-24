using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherAndGeoLocationServices.Models.Weather;

namespace WeatherAndGeoLocationServices.Services
{
    public class ForecastService : IForecastService
    {
        private static readonly HttpClient Client = new HttpClient();
        string IDOWeather = Constants.OPEN_WEATHER_APPID;
        public async Task<WeatherResponse> GetForecast(string cityCode)
        {
            try
            {
                using HttpClient client = new HttpClient();
                var response =
                    await client.GetAsync(
                        $"http://api.openweathermap.org/data/2.5/weather?id={cityCode}&APPID={IDOWeather}");
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherResponse>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;

        }
    }
}
