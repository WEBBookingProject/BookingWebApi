using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;
using BookingWebApi.BookingWebApi.Dto.ModelsDto;
using BookingWebApi.BookingWebApi.Security.Hashers;
using BookingWebApi.BookingWebApi.Security.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Reflection;

namespace BookingWebApi.BookingWebApi.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JwtProvider _jwtProvider;

        public UserService(UserRepository repository, IPasswordHasher hasher, JwtProvider jwtProvider)
        {
            _repository = repository;
            _passwordHasher = hasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> RegisterAsync(string name, string displayName, string photoLink,
            string email, string password, int phoneNumber, string nationality,
            DateTime birthDate, string gender)
        {
            var hashedPassword = _passwordHasher.GenerateHash(password);

            if (_repository.GetUserAsName(name) == null)
            {
                var user = new User
                {
                    Name = name,
                    DisplayName = displayName,
                    Photo = photoLink,
                    Email = email,
                    PasswordHash = hashedPassword,
                    PhoneNumber = phoneNumber,
                    Nationality = nationality,
                    BirthDate = birthDate,
                    Gender = gender
                };

                await _repository.AddAsync(user);

                string res = _jwtProvider.GenerateToken(user.Id, user.Role);

                return res;
            }

            return "exception";
        }

        public async Task<bool> Login(string name, string password)
        {
            var user = _repository.GetUserAsName(name);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            return result;
        }

        public async Task UpdateProfile(Guid id, UserDto user)
        {
            var oldUser = await _repository.GetById(id);

            await _repository.Update(oldUser.ToUser(user));
        }

        public UserDto GetUserProfile(string name)
        {
            var user = _repository.GetUserAsName(name);

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Photo = user.Photo,
                Role = user.Role,
                Nationality = user.Nationality,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                HistoryBookingsId = user.HistoryBookingsId,
                SavedPropertysId = user.SavedPropertysId
            };
        }


    }
}
