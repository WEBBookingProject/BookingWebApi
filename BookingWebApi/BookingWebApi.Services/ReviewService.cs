using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;
using BookingWebApi.BookingWebApi.Services.Interfaces;

namespace BookingWebApi.BookingWebApi.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ReviewRepository _repository;

        public ReviewService(ReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Review>> Get3LastPositiveForProperty(string propertyId)
        {
            var res = await _repository.GetAllAsync();

            return res.OrderByDescending(r => r.OverallRating)
                .Where(r => r.PropertyId == propertyId)
                .Take(3)
                .ToList();
        }

        public async Task<List<Review>> Get3LastPositive()
        {
            var res = await _repository.GetAllAsync();

            return res.OrderBy(r => r.CreatedAt.Ticks)
                .Take(3)
                .ToList();
        }
    }
}
