using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.Services;
using BookingWebApi.BookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService;
        private readonly IClientService _clientService;

        public BookingController(ILogger<BookingController> logger,
            IBookingService bookingService, IClientService clientService)
        {
            _logger = logger;
            _bookingService = bookingService;
            _clientService = clientService;
        }

        [HttpPost("CreateNewBooking")]
        public async Task<IActionResult> CreateNewBooking(string propertyId, decimal totalPrice,
            DateTime startDate, DateTime endDate, BookingStatus status,
            string userId = "", string clientId = "")
        {
            var isClient = _clientService.GetClientById(clientId);

            if (isClient == null) 
                return Content("Create a client or wait a bit");

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
