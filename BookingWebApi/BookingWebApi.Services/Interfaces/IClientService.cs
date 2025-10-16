using BookingWebApi.BookingWebApi.Core.Models;

namespace BookingWebApi.BookingWebApi.Services.Interfaces
{
    public interface IClientService
    {
        Task AddClient(string fullName, int phoneNumber, string email);

        Task<Client?> GetClientById(string id);

        Task<Client?> GetClientByPhoneNumber(int phoneNumber);
    }
}
