namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Object
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public float Rating { get; set; }
        public string Address { get; set; } = null!;
        public Coordinates Coordinates { get; set; }
        public DatesForBooking DatesForBooking { get; set; }


        //public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public struct Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public struct DatesForBooking
    {
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
    }
}
