using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class PropertyRepository : BaseRepository<Property>
    {
        public PropertyRepository(BookingWebApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
