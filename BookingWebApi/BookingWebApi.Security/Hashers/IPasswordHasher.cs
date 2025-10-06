namespace BookingWebApi.BookingWebApi.Security.Hashers
{
    public interface IPasswordHasher
    {
        public string GenerateHash(string str);
        public bool Verify(string str, string hashedStr);
    }
}
