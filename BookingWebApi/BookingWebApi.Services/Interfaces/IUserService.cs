using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;
using BookingWebApi.BookingWebApi.Dto.ModelsDto;
using BookingWebApi.BookingWebApi.Security.JWT;

namespace BookingWebApi.BookingWebApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(string name, string displayName, string photoLink,
            string email, string password, int phoneNumber, string nationality,
            DateTime birthDate, string gender);

        Task<bool> Login(string name, string password);

        Task UpdateProfile(Guid id, UserDto user);

        UserDto GetUserProfile(string name);
    }
}
