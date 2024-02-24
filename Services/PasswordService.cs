using System.Security.Cryptography;
using dotnetapi.Interfaces;

namespace dotnetapi.Services;

public class PasswordService : IPasswordService
{
    public void CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }


}