using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;
using BookingWebApi.BookingWebApi.Security.Hashers;
using Microsoft.EntityFrameworkCore;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(BookingWebApiDbContext dbContext) : base(dbContext)
        {
        }

        public User GetUserAsName(string name)
        {
            var result = this._dbSet.FirstOrDefault(u => u.Name == name);

            return result;
        }
    }
}
