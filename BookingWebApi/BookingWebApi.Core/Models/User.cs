namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }

        //Personal Data
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Photo { get; set;} = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "user"; // "admin", "user"
        public int PhoneNumber { get; set; }
        public string Nationality { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; } = null!;
        
        public List<User> Friends { get; set; } = new List<User>();
        public List<Booking> History { get; set; } = new List<Booking>();
        public List<Object> Saved { get; set; } = new List<Object>();


        //public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
