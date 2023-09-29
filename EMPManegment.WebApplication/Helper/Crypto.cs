using System.Security.Cryptography;

namespace EMPManegment.Web.Helper
{
    public static class Crypto
    {
        public static void Hash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public static string Token(string value)
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        public static bool VarifyHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHase = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHase.SequenceEqual(passwordHash);
            }

        }
    }
}

