using BookingWebApi.BookingWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ClientService _clientService;

        public ClientController(ILogger<ClientController> logger,
            ClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClientAsync(string fullName, int phoneNumber, string email)
        {
            await _clientService.AddClient(fullName, phoneNumber, email);

            return Ok();
        }
    }
}
