namespace BookingWebApi.BookingWebApi.Dto.ModelsDto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = "user"; // "admin", "user"
        public int PhoneNumber { get; set; }
        public string Nationality { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;

        public List<string> HistoryBookingsId { get; set; } = new List<string>();
        public List<string> SavedPropertysId { get; set; } = new List<string>();
    }
}
