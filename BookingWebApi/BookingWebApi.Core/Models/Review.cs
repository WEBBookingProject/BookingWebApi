namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string PropertyId { get; set; }
        public string UserId { get; set; } = null!;
        public string Text { get; set; } = null!;
        public float OverallRating { get; set; }

        public float Cleanliness { get; set; }
        public float Comfort { get; set; }
        public float Location { get; set; }
        public float Facilities { get; set; }
        public float Staff { get; set; }
        public float ValueForMoney { get; set; }
    }
}
