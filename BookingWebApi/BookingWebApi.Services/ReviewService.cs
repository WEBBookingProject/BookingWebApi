using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BookingWebApi.BookingWebApi.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository _repository;

        public ReviewService(ReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Review>> Get3LastPositive(string propertyId)
        {
            var res = await _repository.GetAllAsync();

            return res.OrderByDescending(r => r.OverallRating)
                .Where(r => r.PropertyId == propertyId)
                .Take(3)
                .ToList();
        }
    }
}
