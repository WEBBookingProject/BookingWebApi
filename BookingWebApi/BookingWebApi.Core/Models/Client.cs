namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Guid> BookingHistory { get; set; } = new List<Guid>();
    }
}
