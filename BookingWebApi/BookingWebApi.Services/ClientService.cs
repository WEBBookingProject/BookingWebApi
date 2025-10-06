using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;

namespace BookingWebApi.BookingWebApi.Services
{
    public class ClientService
    {
        private readonly ClientRepository _repository;

        public ClientService(ClientRepository repository)
        {
            _repository = repository;
        }

        public async Task AddClient(string fullName, int phoneNumber, string email)
        {
            await _repository.AddAsync(new Client
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Email = email
            });
        }
    }
}
