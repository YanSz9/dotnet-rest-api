using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using dotnetapi.Interfaces;
using dotnetapi.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnetapi.Services;

public class PasswordService : IPasswordService
{
    private readonly IConfiguration _config;
    public PasswordService(IConfiguration config)
    {
        _config = config;
    }
    public void CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
    public bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
    public string CreateToken(UserViewModel user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim("Role", user.Role.ToString()),
            new Claim("Email", user.Email),
            new Claim("Username", user.User)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials

        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

}