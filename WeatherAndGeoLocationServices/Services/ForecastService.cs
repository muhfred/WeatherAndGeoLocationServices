using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAndGeoLocationServices.Config;

namespace WeatherAndGeoLocationServices.Services
{
    public class ForecastService : IForecastService
    {
        private static readonly HttpClient Client = new HttpClient();
        string IDOWeather = Constants.OPEN_WEATHER_APPID;
        public async Task<object> GetForecast(string cityCode)
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
                    return JsonConvert.DeserializeObject<object>(jsonString);
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
