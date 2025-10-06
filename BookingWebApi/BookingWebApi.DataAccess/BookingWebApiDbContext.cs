using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BookingWebApi.BookingWebApi.Core.Models;

namespace BookingWebApi.BookingWebApi.DataAccess.Repositories
{
    public class BookingWebApiDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public BookingWebApiDbContext(DbContextOptions<BookingWebApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Property>()
                .HasKey(p =>  p.Id);

            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }
    }
}
