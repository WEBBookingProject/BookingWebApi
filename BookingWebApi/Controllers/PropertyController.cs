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

        [HttpPost("CreatePropetry")]
        public async Task<IActionResult> CreateProperty()
        {
            var roomDetails = new Description
            {
                Text = "Spacious apartment with modern amenities",
                Type = "Apartment",
                Location = "City Center",
                SleepingArrangements = 2,
                AppartamentSize = 75,
                WiFi = true,
                FreeWiFi = true,
                ParkingPlaces = 1,
                Kitchen = true
            };

            var accommodation = new Property
            {
                Name = "Grand Hotel",
                Description = roomDetails,
                PriceForDay = 250.75m,
                MaxGuests = 4,
                Rating = 4.7,
                Address = "123 Ocean Boulevard, Miami, FL",
                LatitudeCoordinate = 25.7617,
                LongitudeCoordinate = -80.1918,
                Category = "Luxury",
                Photos = new List<string>
                {
                    "photo1.jpg",
                    "photo2.jpg",
                    "photo3.jpg"
                },
                CreatedAt = DateTime.UtcNow,
                ContactPhone = "+1-555-0123",
                ContactEmail = "info@grandhotel.com"
            };

            await _propertyService.AddProperty(accommodation);

            return Ok();
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
