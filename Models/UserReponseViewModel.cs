using System.ComponentModel.DataAnnotations;
using dotnetapi.Enums;

namespace dotnetapi.Models;

public class UserResponseViewModel
{
    [Required(ErrorMessage = "The field user is required")]
    public string User { get; set; }
    [Required(ErrorMessage = "The field email is required"), EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "The field password is required")]
    public string Password { get; set; }
    [Compare("Password", ErrorMessage = "Pasword doesnt match")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "The field role is required")]
    public RoleEnum Role { get; set; }
}