using BookingWebApi.BookingWebApi.Core.Models;

namespace BookingWebApi.BookingWebApi.Services.Interfaces
{
    public interface IPropertyService
    {
        Task AddProperty(Property prop);

        Task<Property> GetById(string propertyId);

        Task<List<Property>> SearchProperty(int minPrice = 0, int maxPrice = 0,
            int parkingPlaces = 0, int apartamentSize = 0,
            double rating = 0, string category = null, bool kitchen = false,
            bool wifi = false, bool freeWifi = false);

        Task<List<Property>> GetTop10ByRating();
    }
}
