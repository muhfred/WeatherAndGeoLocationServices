using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAndGeoLocationServices.Config;

namespace WeatherAndGeoLocationServices.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        private static readonly HttpClient Client = new HttpClient();
        string GeoKey = Constants.ZIP_CODE_APIKEY;
        public async Task<object> GetGeoInfo(string zipCode)
        {
            try
            {
                using HttpClient client = new HttpClient();
                var response =
                    await client.GetAsync(
                        $"https://www.zipcodeapi.com/rest/{GeoKey}/info.json/{zipCode}/degrees");
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
