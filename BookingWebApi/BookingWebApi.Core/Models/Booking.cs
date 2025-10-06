namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string PropertyId { get; set; }
        public string ClientId { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public DateTime StartDateForBooking { get; set; }
        public DateTime EndDateForBooking { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending; //Pending, Confirmed, Cancelled
    }

    public enum BookingStatus { Pending, Confirmed, Cancelled }

    //public struct DatesForBooking
    //{
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //}
}
