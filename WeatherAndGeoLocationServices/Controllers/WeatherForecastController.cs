using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAndGeoLocationServices.Services;

namespace WeatherAndGeoLocationServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string cityCode)
        {
            var response = await _forecastService.GetForecast(cityCode);
            return new JsonResult(response);
        }
    }
}
