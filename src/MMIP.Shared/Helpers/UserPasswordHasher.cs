using System.Security.Cryptography;

namespace MMIP.Shared.Helpers
{
    public class UserPasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(0x20);
            }
            byte[] destination = new byte[0x31];
            Buffer.BlockCopy(salt, 0, destination, 1, 0x10);
            Buffer.BlockCopy(buffer, 0, destination, 0x11, 0x20);
            return Convert.ToBase64String(destination);
        }
    }
}
