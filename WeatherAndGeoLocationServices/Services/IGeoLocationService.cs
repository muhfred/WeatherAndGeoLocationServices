using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAndGeoLocationServices.Services
{
    public interface IGeoLocationService
    {
        Task<object> GetGeoInfo(string zipCode);
    }
}
