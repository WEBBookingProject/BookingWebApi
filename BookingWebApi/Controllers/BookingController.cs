using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BookingService _bookingService;

        public BookingController(ILogger<WeatherForecastController> logger,
            BookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpPost("CreateNewBooking")]
        public async Task<IActionResult> CreateNewBooking(string propertyId, decimal totalPrice,
            DateTime startDate, DateTime endDate, BookingStatus status,
            string userId = "", string clientId = "")
        {
            await _bookingService.AddBooking(propertyId, totalPrice, startDate,
                endDate, status, userId, clientId);

            return Ok();
        }

        [HttpGet("GetBookingsForUserOrClientId")]
        public async Task<IActionResult> GetBookingsForUserOrClientIdAsync(string userId = null, string clientId = null)
        {
            List<Booking> res;

            if (userId == null)
            {
                res = await _bookingService.GetBookingsForClientId(clientId);

                return Ok(res);
            }

            res = await _bookingService.GetBookingsForUserId(userId);

            return Ok(res);
        }
    }
}
