namespace dotnetapi.Interfaces;

public interface IPasswordService
{
    void CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
}