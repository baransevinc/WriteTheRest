using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            // Basit örnek, gerçek projede güçlü bir hash algoritması kullan!  
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
