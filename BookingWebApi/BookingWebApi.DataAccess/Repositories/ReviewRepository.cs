using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(BookingWebApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
