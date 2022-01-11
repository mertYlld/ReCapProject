using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //password keyi oluşur
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //password keyi karşılaştır
        //daha önce gönderdiğinle bu örtüşücek 
        //yanlışsa hatalı bi hash ortaya çıkıcak
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passworSalt)
        //str password --> kullanıcının sonradan girdiği parola
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passworSalt))
            {
                var compultedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < compultedHash.Length; i++)
                {
                    if (compultedHash[i] != passwordHash[i])//veritabanıyla kullanıcının gönderdiği parolayı karşılaştırıyoruz
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
