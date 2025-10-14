using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;
using BookingWebApi.BookingWebApi.Services.Interfaces;

namespace BookingWebApi.BookingWebApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingRepository _repository;

        public BookingService(BookingRepository repository)
        {
            _repository = repository;
        }

        public async Task AddBooking(string propertyId, decimal totalPrice,
            DateTime startDate, DateTime endDate, BookingStatus status,
            string userId = "", string clientId = "")
        {
            var utcStartDate = startDate.Kind == DateTimeKind.Utc
                ? startDate
                : DateTime.SpecifyKind(startDate, DateTimeKind.Utc);

            var utcEndDate = endDate.Kind == DateTimeKind.Utc
                ? endDate
                : DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            await _repository.AddAsync(new Booking
            {
                PropertyId = propertyId,
                TotalPrice = totalPrice,
                StartDateForBooking = utcStartDate,
                EndDateForBooking = utcEndDate,
                Status = status,
                UserId = userId,
                ClientId = clientId
            });
        }

        public async Task<List<Booking>> GetBookingsForUserId(string userId)
        {
            var res = await _repository.GetAllAsync();

            return res.Where(b => b.UserId == userId).ToList();
        }

        public async Task<List<Booking>> GetBookingsForClientId(string clientId)
        {
            var res = await _repository.GetAllAsync();

            return res.Where(b => b.ClientId == clientId).ToList();
        }
    }
}
