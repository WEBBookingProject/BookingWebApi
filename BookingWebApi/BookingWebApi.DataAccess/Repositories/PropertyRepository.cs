using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class PropertyRepository : BaseRepository<Property>
    {
        public PropertyRepository(BookingWebApiDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<List<Property>> GetAllAsync()
        {
            var res = await this._dbSet.Include(p =>  p.Description).ToListAsync();

            return res;
        }
    }
}
