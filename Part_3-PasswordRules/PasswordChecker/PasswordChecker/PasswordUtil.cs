using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{


    /// <summary>
    /// Simple static class to help in hashing of some passwords for the demo
    /// </summary>
    public class PasswordUtil
    {

        /// <summary>
        /// Hashes a salt/password combo with SHA256
        /// </summary>
        /// <remarks>
        /// This is just for demo purposes.  In real like, use a better hash algorithm like bcrypt as SHA256
        /// is no longer considered safe
        /// </remarks>
        /// <param name="salt">A String of the salt</param>
        /// <param name="password">A String of the password to hash</param>
        /// <returns>A String of the hexadecimal encoded hashed password value</returns>
        public static String HashPassword(String salt, string password)
        {
            String combinedValue = salt + password;
            byte[] hashedValue = null;

            using (HashAlgorithm hashAlg = HashAlgorithm.Create("SHA256"))
            {

                hashedValue = hashAlg.ComputeHash((Encoding.UTF8).GetBytes(combinedValue));
            }

            return ToHexadecimalString(hashedValue);
        }


        /// <summary>
        /// Converts an array of bytes to a hexadecimal string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static String ToHexadecimalString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(string.Format("{0:X2}", b));
            }

            return sb.ToString();
        }

    }
}
