using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class BookingRepository : BaseRepository<Booking>
    {
        public BookingRepository(BookingWebApiDbContext db) : base(db)
        {
        }


        public List<Booking> GetBookingForUserId(Guid userId)
        {
            var res = this._dbSet.Where(b => b.UserId.ToString() == userId.ToString());

            return res.ToList();
        }
    }
}
