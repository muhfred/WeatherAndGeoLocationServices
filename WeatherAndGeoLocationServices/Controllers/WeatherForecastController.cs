using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherAndGeoLocationServices.Models.Weather;
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
            WeatherResponse weatherResponse = await _forecastService.GetForecast(cityCode);
            return new JsonResult(weatherResponse);
        }
    }
}
