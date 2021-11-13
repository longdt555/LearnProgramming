
using System.Security.Cryptography;
using System.Text;

namespace StoreManagement.Common.Helpers
{
    public class Security
    {

        private static readonly object Locker = new object();

        private static string Md5Hash(string src)
        {
            var hash = new StringBuilder();
            var md5Provider = new MD5CryptoServiceProvider();
            var bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(src));

            foreach (var t in bytes)
            {
                hash.Append(t.ToString("x2"));
            }
            return hash.ToString();
        }

        public static string Cryptography(string inp)
        {
            lock (Locker)
            {
                return Md5Hash(inp);
            }
        }
    }
}
