namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Property
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public Description Description { get; set; } = null!;
        public decimal PriceForDay { get; set; }
        public int MaxGuests { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; } = null!;
        public double LatitudeCoordinate { get; set; }
        public double LongitudeCoordinate { get; set; }
        public string Category { get; set; } = null!; // 5-star, Budget, Luxury, etc.
        public List<string> Photos { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string ContactPhone { get; set; } = null!; //Желательно автозаполнение от автора поста
        public string ContactEmail { get; set; } = null!; //То же самое

        //public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
