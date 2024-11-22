using System;
using System.Security.Cryptography;

namespace GoldDigger.Model
{


    public class PasswordHasher

    {

        public static (string Hash, string Salt) HashPassword(string password)

        {

            // Generate a salt

            byte[] salt = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())

            {

                rng.GetBytes(salt);

            }


            // Hash the password with the salt

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000)) // 100,000 iterations

            {

                byte[] hash = pbkdf2.GetBytes(20); // 20 bytes hash


                // Combine salt and hash for storage

                byte[] hashBytes = new byte[36];

                Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);

                Buffer.BlockCopy(hash, 0, hashBytes, 16, 20);


                // Convert to Base64 for storage

                string savedHash = Convert.ToBase64String(hashBytes);

                string savedSalt = Convert.ToBase64String(salt);

                return (savedHash, savedSalt);

            }

        }

        public static bool VerifyPassword(string inputPassword, string storedHash, string storedSalt)

        {

            // Convert the stored hash and salt back to byte arrays

            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = Convert.FromBase64String(storedSalt);


            // Hash the input password with the extracted salt

            using (var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 100000))

            {

                byte[] hash = pbkdf2.GetBytes(20); // 20 bytes hash


                // Compare the hashes

                for (int i = 0; i < 20; i++)

                {

                    if (hashBytes[i + 16] != hash[i])

                    {

                        return false; // Password does not match

                    }

                }

            }

            return true; // Password matches

        }
    }
}
