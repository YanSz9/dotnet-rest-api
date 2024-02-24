namespace dotnetapi.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string User { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public Datetime TokenCreatedAt { get; set; } = DateTime.Now;

}