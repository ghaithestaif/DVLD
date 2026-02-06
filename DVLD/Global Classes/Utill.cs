

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;

namespace DVLD.Util
{
    internal class Utill
    {

        static string GenerateSaltString()
        {
            byte[] salt = new byte[16]; // 16 bytes = good random salt

            // Fill with cryptographically secure random bytes
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Convert to Base64 string to store safely in DB
            return Convert.ToBase64String(salt);
        }
        public static string HashPassword(string password)
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




        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }
        static public bool CreateFolderIfDoesNotExist(string Path)
        {
            if (!Directory.Exists(Path))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(Path);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
            return true;

        }
        static public string RenameFileWithGUID(string OriginalFilePath)
        {
            string extension=Path.GetExtension(OriginalFilePath);
            return GenerateGUID() + extension;
        }
        static public bool CopyImageToProjectFolder(ref string SourceFile)
        {
            string DestinationFolder = @"D:\Users\GhaithEstaif\source\repos\DVLD\DVLD\People\Images\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }
            string DestinationFile = DestinationFolder + RenameFileWithGUID(SourceFile);
            try
            {

                File.Copy(SourceFile, DestinationFile, true);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying file: " + ex.Message);
                return false;

            }
            SourceFile = DestinationFile;
            return true;


        }
    }
}
