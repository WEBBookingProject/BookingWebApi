using BookingWebApi.BookingWebApi.Core.Models;

namespace BookingWebApi.BookingWebApi.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> Get3LastPositiveForProperty(string propertyId);

        Task<List<Review>> Get3LastPositive();
    }
}
