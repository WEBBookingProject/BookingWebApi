namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Response
    {
        public Guid Id { get; set; }

        public Object Object { get; set; } = null!;
        public string Text { get; set; } = null!;
        public float Rating { get; set; }
        public User Author = null!;
    }
}
