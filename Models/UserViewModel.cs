using dotnetapi.Enums;

namespace dotnetapi.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string User { get; set; }
    public RoleEnum Role { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime TokenCreatedAt { get; set; } = DateTime.Now;

}