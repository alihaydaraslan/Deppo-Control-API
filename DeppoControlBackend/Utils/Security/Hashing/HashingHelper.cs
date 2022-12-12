using System.Security.Cryptography;
using System.Text;

namespace DeppoControlBackend.Utils.Security.Hashing
{
    public class HashingHelper
    {
        public static string Md5Hash(string? text)
        {
            MD5 md5 = MD5.Create();
            if (text != null) _ = md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            byte[]? result = md5.Hash;

            var strBuilder = new StringBuilder();
            if (result != null)
                foreach (var data in result)
                {
                    strBuilder.Append(data.ToString("x2"));
                }

            return strBuilder.ToString();
        }
    }
}
