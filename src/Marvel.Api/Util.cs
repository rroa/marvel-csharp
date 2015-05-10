using System;
using System.Security.Cryptography;
using System.Text;

namespace Marvel.Api
{
    public static class Util
    {
        /// <summary>
        /// Generates MD5 hash for a given input
        /// </summary>
        /// <param name="input">
        /// Input to be hashed
        /// </param>
        /// <returns>
        /// Input md5 digest
        /// </returns>
        public static string CalculateMd5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns the current unix timestamp
        /// </summary>        
        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
    }
}
