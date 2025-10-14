namespace BookingWebApi.BookingWebApi.Services.Interfaces
{
    public interface IClientService
    {
        Task AddClient(string fullName, int phoneNumber, string email);
    }
}
