using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Crypto-related extension methods
    /// </summary>
    public static class Cryptography
    {
        /// <summary>
        /// Hash a string (SHA512) given a salt
        /// </summary>
        /// <param name="value"></param>
        /// <param name="salt"></param>
        /// <returns>Base64 encoded string.  Since this is SHA512, the string will be exactly 88 characters long</returns>
        public static string HashWithSalt(this string value, string salt)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (salt == null) throw new ArgumentNullException("salt");
            return value.Hash(ref salt);
        }

        /// <summary>
        /// Hash a string (SHA512) given a salt.  The string will be normalized (lowercased) prior to hashing.  This is meant
        /// for case insensitive comparisons when a later string is hashed with the same salt
        /// </summary>
        /// <param name="value"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashLowercaseWithSalt(this string value, string salt)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (salt == null) throw new ArgumentNullException("salt");
            return value.HashLowercase(ref salt);
        }

        /// <summary>
        /// Hash a string (SHA512).  A cryptographically random salt will be generated and 
        /// provided to the calling method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string Hash(this string value, ref string salt)
        {
            if (value == null) throw new ArgumentNullException("value");
            salt = salt ?? CreateRandomSalt().ToString();
            using (var hashAlgorithm = SHA512.Create()) {
                byte[] preHash = System.Text.Encoding.UTF32.GetBytes(value + salt);
                byte[] hash = hashAlgorithm.ComputeHash(preHash);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Hash a string (SHA512) given a salt.  The string will be normalized (lowercased) prior to hashing.  This is meant
        /// for case insensitive comparisons when a later string is hashed with the same salt.  A cryptographically 
        /// random salt will be generated and provided to the calling method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashLowercase(this string value, ref string salt)
        {
            if (value == null) throw new ArgumentNullException("value");
            salt = salt ?? CreateRandomSalt().ToString();
            salt = salt.ToLowerInvariant();
            return value.ToLowerInvariant().Hash(ref salt);
        }

        // Define other methods and classes here
        private static ulong CreateRandomSalt()
        {
            var saltBytes = new Byte[8];
            object rng = null;
            try {
                rng = new RNGCryptoServiceProvider();
                ((RNGCryptoServiceProvider)rng).GetBytes(saltBytes);
            }
            finally {
                // .NET >= 4, RNGCryptoServiceProvider is IDispoable
                // This mess of code (above and below) will support 
                // this discrepancy
                var disposable = rng as IDisposable;
                if (disposable != null) {
                    try {
                        disposable.Dispose();
                    }
                    catch (Exception) { }
                }
            }

            return
            (
              (((ulong)saltBytes[0]) << 56) +
              (((ulong)saltBytes[1]) << 48) +
              (((ulong)saltBytes[2]) << 40) +
              (((ulong)saltBytes[3]) << 32) +
              (((ulong)saltBytes[4]) << 24) +
              (((ulong)saltBytes[5]) << 16) +
              (((ulong)saltBytes[6]) << 8) +
              saltBytes[7]
            );
        }
    }

}
