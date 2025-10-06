using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected BookingWebApiDbContext _db;
        protected DbSet<T> _dbSet;

        public BaseRepository(BookingWebApiDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var res = await _dbSet.ToListAsync();
            return res;
        }

        public async Task<T> GetById(Guid id)
        {
            var res = await _dbSet.FirstOrDefaultAsync(b => EF.Property<Guid>(b,"Id") == id);
            return res;
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
