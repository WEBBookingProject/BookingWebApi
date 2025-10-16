using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;
using BookingWebApi.BookingWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BookingWebApi.BookingWebApi.Services
{
    public class ClientService : IClientService
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

        public async Task<Client?> GetClientById(string id)
        {
            var res = await _repository.GetAllAsync();

            return res.FirstOrDefault(c => c.Id.ToString() == id);
        }

        public async Task<Client?> GetClientByPhoneNumber(int phoneNumber)
        {
            var res = await _repository.GetAllAsync();

            return res.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        }
    }
}
