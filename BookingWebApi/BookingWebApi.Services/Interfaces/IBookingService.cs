using BookingWebApi.BookingWebApi.Core.Models;

namespace BookingWebApi.BookingWebApi.Services.Interfaces
{
    public interface IBookingService
    {
        Task AddBooking(string propertyId, decimal totalPrice,
            DateTime startDate, DateTime endDate, BookingStatus status,
            string userId = "", string clientId = "");

        Task<List<Booking>> GetBookingsForUserId(string userId);

        Task<List<Booking>> GetBookingsForClientId(string clientId);
    }
}
