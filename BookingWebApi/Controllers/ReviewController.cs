using BookingWebApi.BookingWebApi.Services;
using BookingWebApi.BookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> logger,
            IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }

        [HttpGet("Get3LastPositiveByPropertyAsync")]
        public async Task<IActionResult> Get3LastPositiveByPropertyAsync(string propertyId)
        {
            var res = await _reviewService.Get3LastPositiveByProperty(propertyId);

            return Ok(res);
        }

        [HttpGet("Get3LastPositiveAsync")]
        public async Task<IActionResult> Get3LastPositiveAsync()
        {
            var res = await _reviewService.Get3LastPositive();

            return Ok(res);
        }
    }
}
