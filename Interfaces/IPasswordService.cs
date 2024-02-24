using dotnetapi.Models;

namespace dotnetapi.Interfaces;

public interface IPasswordService
{
    void CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
    bool VerifyHashPassword(string password, byte[] passwordSalt, byte[] passwordHash);
    string CreateToken(UserViewModel user);
}