using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QDecryptor
{
    static class Program
    {
        //MODIFY ACCORDINGLY
        public static string string_0 = "vFY24NKl+IgwmRhDdoVWqYKC3Zr2VxZHX/w+09nWrGuL7fNBC736ingLCmLbgenOg5EWq1l/uGP3bFbEJmIocw==";
        public static string string_1 = "TpsMeGHIh+oJhT+pxGZd8fZwfyWmPNuwjuUIGNUzda7NIqyv/eINIZPOwF9VGnMdW328xjEr0/H8MTuKQ15JniYVOEOSu+lpFHbc3OrzYJI=";
        public static string string_3 = "UYtwxA/JF4CPCoWkgasE702GIAaiwPSxc0SOQkjG5S0uZn2Q8A72sC1BTCUJ27t1eOMDaaYfmH4iHWme4CoK4g==";
        public static string string_4 = "5cNOykJvNdbXcvg5ChxIpll4Mh3f9TOg+rlzA1pRL1wO7ulhtCjZ9a/pe3AUrihaG0SRPUjXbsp3UQocZlvfuA==";
        public static string string_5 = "qsaXxYUf1/EqPW0xEjIcPQ4cYW7OFVZcsyB0GE94ia0xjvnRySwjzSsVkCPmAXpcNkvojLMvtX88HBfLsgkPIF+Br4YjMnj/XzHNnoCZzpzqE0mhqRxRqyB1fQGdSiAq";
        public static string string_6 = "LOR+aHfJUQ5Wi3LnjbbuCUAkAlzRY0aM3PizGQQNSnkuyjkcylRWyHhlD1pPQ1apnHsztNU0CKhSMGXmc+CrDtL/4UXXM94ylv1fLiWXkFU=";
        public static string string_7 = "55EB2E1843F80C77B8671913E13E8BFA34B6C604"; // ENCRYPTION KEY
        public static string string_8 = "oET56O0lenwZAOrnFdzw4/qHSXaISHi+tY1S8LywLq88En7xlVL7IvrEQwKJzfT7NRpoKECh6Z+F9fptDXSElg==";
        public static string string_9 = "WLc25XdrNClae7trBeLDeeYC+DZFP4rh08AJmsJkHm2MU2Wwhlriu+wTlXzQL2YOnZ48kLiTZ+gAcCRBq/+qTQ==";
        public static string string_10 = "GB/FlhUeDCcchRUqJ6XJ9gUDHg3mClUL6MEzBOetONdKnXFbOreTro3zksKqO1aOYt/DkxuSwgXR5MHKjP2gzoEYHvmSttxEiu3XvuCFEwf1WVzaVN5GD3qM9MApWAJOKVLUpwTzJkoam1xt1yXyNH8eDC4mene8nX2kdm46C/goIaRrK3l2dGIWogkDvlJJlNgRcJYoBgj/fOXL6zoaWvuDr/fyPKXcTs/yqzaEisPcm56nGLK+HgZ1Vvob+UAcD0zhcLcxm0/ReK8rPKi4dewO1toTjpaRr0sCVr7rl5nY/aRAICizSfx+k3IXvoEt5nSEHzhyrrI+OClfSnEYIKNMNlJJJYrAmS/vPTGPxhcRSYBkTacjJK/Of9LHsd8F3WoFBV1nWZCs1w/oLWj+PRKCMXcE2NSg+xUyU61FoV+73mvwwwnLJBHgb9NiHTjMG8BXzdpReBuh9SoeeC+u7yrFWuKcEsuE/XNNSDi8e2Vnn6w/vDjfkBVCaNcr4zyaT3dHw6m4l6WWlHIXByr60RMQXcl0t3Z2UKettjl8Q2lJpK+gW6ru2g4BjfFQsMaOfVQtUrWXTgKPR79XUuNi9UBgRx1TgrFZVuwNzlX6SRF6NGExoUC8CKelW2zJl/as4Lbc51bfNxCqEDrPRwIxRxWAZnY2k6iozN5Re980qQMDN15QMPM6L6+Iq1/MBwMEuAH+cfPcBUvjXyYs8RXMn2gfRPKkShvz9YW9rC4S+vzzDCAch5KO8rjnBXIGBiBt7tCvZo7ExX8nlUUomg6jYTTIQcnm0RJnApEdoUo1jB25eOMU09QGfWuO6rZcI3EwCoQE258whYCghqFrW+ZlAnc/oja1hZSxSjyuYoa50SohUBEaNr6iN/ETb0bra+8EFOFNa+6wQuTXBu1sbo36h1iVceE4K+L2wYbfHiHXspzG6D1WT51L5AFUEo+R5oZooWZlL6IhqTf0RBOkhwQ+cA==";
        public static string string_11 = "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";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var aes = new Aes256(string_7); // INITIALIZE AES WITH ENCRYPTION KEY
            string_0 = aes.Decrypt(string_0);
            string_1 = aes.Decrypt(string_1);
            string_3 = aes.Decrypt(string_3);
            string_4 = aes.Decrypt(string_4);
            string_5 = aes.Decrypt(string_5);
            string_6 = aes.Decrypt(string_6);
            string_8 = aes.Decrypt(string_8);
            string_9 = aes.Decrypt(string_9);
            string_10 = aes.Decrypt(string_10);
            string_11 = aes.Decrypt(string_11);

            Console.WriteLine(string_0.ToString());
            Console.WriteLine(string_1.ToString());
            Console.WriteLine(string_3.ToString());
            Console.WriteLine(string_4.ToString());
            Console.WriteLine(string_5.ToString());
            Console.WriteLine(string_6.ToString());
            Console.WriteLine(string_8.ToString());
            Console.WriteLine(string_9.ToString());
            Console.WriteLine(string_10.ToString());
            Console.WriteLine(string_11.ToString());
        }
    }


    public class Aes256
    {
        private const int KeyLength = 32;
        private const int AuthKeyLength = 64;
        private const int IvLength = 16;
        private const int HmacSha256Length = 32;
        private readonly byte[] _key;
        private readonly byte[] _authKey;

        private static readonly byte[] Salt =
        {
            0xBF, 0xEB, 0x1E, 0x56, 0xFB, 0xCD, 0x97, 0x3B, 0xB2, 0x19, 0x2, 0x24, 0x30, 0xA5, 0x78, 0x43, 0x0, 0x3D, 0x56,
            0x44, 0xD2, 0x1E, 0x62, 0xB9, 0xD4, 0xF1, 0x80, 0xE7, 0xE6, 0xC3, 0x39, 0x41
        };

        public Aes256(string masterKey)
        {
            if (string.IsNullOrEmpty(masterKey))
                throw new ArgumentException($"{nameof(masterKey)} can not be null or empty.");

            using (Rfc2898DeriveBytes derive = new Rfc2898DeriveBytes(masterKey, Salt, 50000))
            {
                _key = derive.GetBytes(KeyLength);
                _authKey = derive.GetBytes(AuthKeyLength);
            }
        }

        public string Encrypt(string input)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input)));
        }

        /* FORMAT
         * ----------------------------------------
         * |     HMAC     |   IV   |  CIPHERTEXT  |
         * ----------------------------------------
         *     32 bytes    16 bytes
         */
        public byte[] Encrypt(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException($"{nameof(input)} can not be null.");

            using (var ms = new MemoryStream())
            {
                ms.Position = HmacSha256Length; // reserve first 32 bytes for HMAC
                using (var aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.KeySize = 256;
                    aesProvider.BlockSize = 128;
                    aesProvider.Mode = CipherMode.CBC;
                    aesProvider.Padding = PaddingMode.PKCS7;
                    aesProvider.Key = _key;
                    aesProvider.GenerateIV();

                    using (var cs = new CryptoStream(ms, aesProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        ms.Write(aesProvider.IV, 0, aesProvider.IV.Length); // write next 16 bytes the IV, followed by ciphertext
                        cs.Write(input, 0, input.Length);
                        cs.FlushFinalBlock();

                        using (var hmac = new HMACSHA256(_authKey))
                        {
                            byte[] hash = hmac.ComputeHash(ms.ToArray(), HmacSha256Length, ms.ToArray().Length - HmacSha256Length); // compute the HMAC of IV and ciphertext
                            ms.Position = 0; // write hash at beginning
                            ms.Write(hash, 0, hash.Length);
                        }
                    }
                }

                return ms.ToArray();
            }
        }

        public string Decrypt(string input)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(input)));
        }

        public byte[] Decrypt(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException($"{nameof(input)} can not be null.");

            using (var ms = new MemoryStream(input))
            {
                using (var aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.KeySize = 256;
                    aesProvider.BlockSize = 128;
                    aesProvider.Mode = CipherMode.CBC;
                    aesProvider.Padding = PaddingMode.PKCS7;
                    aesProvider.Key = _key;

                    // read first 32 bytes for HMAC
                    using (var hmac = new HMACSHA256(_authKey))
                    {
                        var hash = hmac.ComputeHash(ms.ToArray(), HmacSha256Length, ms.ToArray().Length - HmacSha256Length);
                        byte[] receivedHash = new byte[HmacSha256Length];
                        ms.Read(receivedHash, 0, receivedHash.Length);

                        if (!SafeComparison.AreEqual(hash, receivedHash))
                            throw new CryptographicException("Invalid message authentication code (MAC).");
                    }

                    byte[] iv = new byte[IvLength];
                    ms.Read(iv, 0, IvLength); // read next 16 bytes for IV, followed by ciphertext
                    aesProvider.IV = iv;

                    using (var cs = new CryptoStream(ms, aesProvider.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] temp = new byte[ms.Length - IvLength + 1];
                        byte[] data = new byte[cs.Read(temp, 0, temp.Length)];
                        Buffer.BlockCopy(temp, 0, data, 0, data.Length);
                        return data;
                    }
                }
            }
        }
    }

    public class SafeComparison
    {
        /// <summary>
        /// Compares two byte arrays for equality.
        /// </summary>
        /// <param name="a1">Byte array to compare</param>
        /// <param name="a2">Byte array to compare</param>
        /// <returns>True if equal, else false</returns>
        /// <remarks>
        /// Assumes that the byte arrays have the same length.
        /// This method is safe against timing attacks.
        /// </remarks>
        ///[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool AreEqual(byte[] a1, byte[] a2)
        {
            bool result = true;
            for (int i = 0; i < a1.Length; ++i)
            {
                if (a1[i] != a2[i])
                    result = false;
            }
            return result;
        }
    }
}
