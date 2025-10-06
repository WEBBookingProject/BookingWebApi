using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(BookingWebApiDbContext dbContext) : base(dbContext) 
        { 
        }
    }
}
