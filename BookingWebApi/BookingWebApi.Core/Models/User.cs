using BookingWebApi.BookingWebApi.Dto.ModelsDto;

namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }

        //Personal Data
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Photo { get; set;} = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "user"; // "admin", "user"
        public int PhoneNumber { get; set; }
        public string Nationality { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;
        
        public List<string> HistoryBookingsId { get; set; } = new List<string>();
        public List<string> SavedPropertysId { get; set; } = new List<string>();
        public List<string> MyProperties { get; set; } = new List<string>();

        public User ToUser(UserDto user)
        {
            var res = new User
            {
                DisplayName = user.DisplayName,
                PhoneNumber = user.PhoneNumber,
                Photo = user.Photo,
                Email = user.Email,
                Role = user.Role,
                Nationality = user.Nationality,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                HistoryBookingsId = user.HistoryBookingsId,
                SavedPropertysId = user.SavedPropertysId
            };

            return res;
        }
    }
}
