using BookingWebApi.BookingWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertyController : ControllerBase
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly PropertyService _propertyService;

        public PropertyController(ILogger<PropertyController> logger,
            PropertyService propertyService)
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

        [HttpPost("SearchProperties")]
        public async Task<IActionResult> SearchProperties(int minPrice = 0, int maxPrice = 0,
            int parkingPlaces = 0, int apartamentSize = 0,
            double rating = 0, string category = null, bool kitchen = false,
            bool wifi = false, bool freeWifi = false)
        {
            var res = await _propertyService.SearchProperty(minPrice, maxPrice, parkingPlaces,
                apartamentSize, rating, category, kitchen, wifi, freeWifi);

            return Ok(res);
        }
    }
}
