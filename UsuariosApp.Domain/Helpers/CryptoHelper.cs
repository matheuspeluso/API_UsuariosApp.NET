using System;
using System.Security.Cryptography;
using System.Text;
namespace UsuariosApp.Domain.Helpers
{
    public class CryptoHelper
    {
        public static string EncryptSHA256(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value),
                "O valor não pode ser nulo ou vazio.");
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash
                (Encoding.UTF8.GetBytes(value));
                return BitConverter.ToString(hashBytes)
                .Replace("-", "").ToLower();

            }
        }
    }
}