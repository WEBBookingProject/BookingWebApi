using BookingWebApi.BookingWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ReviewService _reviewService;

        public ReviewController(ILogger<WeatherForecastController> logger,
            ReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Get3LastPositiveAsync(string propertyId)
        {
            var res = await _reviewService.Get3LastPositive(propertyId);

            return Ok(res);
        }
    }
}
