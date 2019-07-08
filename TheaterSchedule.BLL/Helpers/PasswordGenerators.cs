using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TheaterSchedule.BLL.Helpers
{
    public static class PasswordGenerators
    {
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public static string CreatePasswordHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Value can not be empty");

            using (SHA512 hmac = SHA512Managed.Create())
            {
                return GetStringFromHash(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }       
    }
}
