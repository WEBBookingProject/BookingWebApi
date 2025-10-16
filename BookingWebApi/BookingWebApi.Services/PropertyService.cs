using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;
using BookingWebApi.BookingWebApi.Services.Interfaces;

namespace BookingWebApi.BookingWebApi.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly PropertyRepository _repository;

        public PropertyService(PropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProperty(Property prop)
        {
            await _repository.AddAsync(prop);
        }

        public async Task<Property> GetById(string propertyId)
        {
            var res = await _repository.GetAllAsync();

            return res.FirstOrDefault(p => p.Id.ToString() == propertyId);
        }

        public async Task<List<Property>> SearchProperties(int minPrice = 0, int maxPrice = 0,
            int parkingPlaces = 0, int apartamentSize = 0,
            double rating = 0, string type = null, string category = null, bool kitchen = false,
            bool wifi = false, bool freeWifi = false)
        {
            var prop = await _repository.GetAllAsync();

            return prop
                .Where(p => p.PriceForDay > minPrice)
                .Where(p => maxPrice == 0 || p.PriceForDay < maxPrice)
                .Where(p => parkingPlaces == 0 || p.Description.ParkingPlaces >= parkingPlaces)
                .Where(p => apartamentSize == 0 || p.Description.AppartamentSize >= apartamentSize)
                .Where(p => rating == 0 || p.Rating >= rating)
                .Where(p => type == null || p.Description.Type == type)
                .Where(p => category == null || p.Category == category)
                .Where(p => !kitchen || p.Description.Kitchen)
                .Where(p => !wifi || p.Description.WiFi)
                .Where(p => !freeWifi || p.Description.FreeWiFi)
                .ToList();
        }

        public async Task<List<Property>> GetProperiesByNameAndAddress(string name, string address = null)
        {
            var res = await _repository.GetAllAsync();

            return res
                .Where(p => p.Name.Contains(name))
                .Where(p => p.Address == null || p.Address.Contains(address))
                .ToList();
        }

        public async Task<List<Property>> GetTop10ByRating()
        {
            var res = await _repository.GetAllAsync();

            return res.OrderByDescending(p => p.Rating).Take(10).ToList();
        }
    }
}
