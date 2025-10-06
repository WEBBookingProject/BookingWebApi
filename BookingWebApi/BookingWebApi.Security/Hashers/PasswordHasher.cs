namespace BookingWebApi.BookingWebApi.Security.Hashers
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string str) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(str);

        public bool Verify(string str, string hashedStr) =>
            BCrypt.Net.BCrypt.EnhancedVerify(str, hashedStr);
    }
}
