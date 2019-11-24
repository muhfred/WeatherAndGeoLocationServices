using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAndGeoLocationServices.Models.GeoLocation;
using WeatherAndGeoLocationServices.Services;

namespace WeatherAndGeoLocationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IGeoLocationService _geoLocationService;

        public GeolocationController(IGeoLocationService geoLocationService)
        {
            _geoLocationService = geoLocationService;
        }
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] GeoRequestModel model)
        {
            var geoInfo = await _geoLocationService.GetGeoInfo(zipCode: model.ZipCode);
            return new JsonResult(geoInfo);
        }
    }
}