namespace BookingWebApi.BookingWebApi.Core.Models
{
    public class Description
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public string Type { get; set; } = null!; 
        public string Location { get; set; } = null!;
        public int SleepingArrangements { get; set; } //Спальные места
        public int AppartamentSize { get; set; }
        public bool WiFi { get; set; }
        public bool FreeWiFi { get; set; }
        public int ParkingPlaces { get; set; }
        public bool Kitchen { get; set; }
    }
}
