using BookingWebApi.BookingWebApi.Services;
using BookingWebApi.BookingWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger,
            IClientService clientService)
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

        [HttpGet("GetClientById")]
        public async Task<IActionResult> GetClientById(string id)
        {
            var res = await _clientService.GetClientById(id);

            return Ok(res);
        }

        [HttpGet("GetClientByPhoneNumber")]
        public async Task<IActionResult> GetClientByPhoneNumber(int phoneNumber)
        {
            var res = await _clientService.GetClientByPhoneNumber(phoneNumber);

            return Ok(res);
        }
    }
}
