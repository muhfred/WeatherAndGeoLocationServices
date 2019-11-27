using System.Threading.Tasks;

namespace WeatherAndGeoLocationServices.Services
{
    public interface IForecastService
    {
        Task<object> GetForecast(string cityCode);
    }
}
