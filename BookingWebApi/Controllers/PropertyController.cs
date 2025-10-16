using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.Services;
using BookingWebApi.BookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertyController : ControllerBase
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly IPropertyService _propertyService;

        public PropertyController(ILogger<PropertyController> logger,
            IPropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }


        [HttpGet("GetTop10ForRating")]
        public async Task<IActionResult> GetTop10ForRatingAsync()
        {
            var res = await _propertyService.GetTop10ByRating();

            return Ok(res);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var res = await _propertyService.GetById(id);

            return Ok(res);
        }

        [HttpGet("SearchProperties")]
        public async Task<IActionResult> SearchProperties(int minPrice = 0, int maxPrice = 0,
            int parkingPlaces = 0, int apartamentSize = 0,
            double rating = 0, string type = null, string category = null, bool kitchen = false,
            bool wifi = false, bool freeWifi = false)
        {
            var res = await _propertyService.SearchProperties(minPrice, maxPrice, parkingPlaces,
                apartamentSize, rating, type, category, kitchen, wifi, freeWifi);

            return Ok(res);
        }

        [HttpGet("SearchByNameAndAddress")]
        public async Task<IActionResult> SearchByNameAndAddress(string name, string address = null)
        {
            var res = await _propertyService.GetProperiesByNameAndAddress(name, address);

            return Ok(res);
        }
    }
}
