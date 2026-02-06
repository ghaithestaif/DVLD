using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
namespace TestCode
{
    internal class Program
    {
        public static string HashPasswordWithoutSalt(string password)
        {
            // Convert password string to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Use SHA256 to hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }

        }
        static void Main(string[] args)
        {
            string password = "MyStrongPass123";
            string hash = HashPasswordWithoutSalt(password);

            Console.WriteLine(hash);
            // Example output: "y+F0lN7kSkx9A0YxGq8ZkZJh6gV6Yv0fh7Xk5M+Wz5I="
            //Iu04B0Jb4n7FmakhLk9/b1e0yPCibl+sJuPoYpBK1es=
            //Iu04B0Jb4n7FmakhLk9/b1e0yPCibl+sJuPoYpBK1es=
        }
    }
}
