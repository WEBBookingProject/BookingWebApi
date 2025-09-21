namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ObjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }

    public enum BookingStatus { Pending, Confirmed, Cancelled }
}
