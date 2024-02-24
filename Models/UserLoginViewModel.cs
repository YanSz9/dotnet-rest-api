using System.ComponentModel.DataAnnotations;

namespace dotnetapi.Models;

public class UserLoginViewModel
{
    [Required(ErrorMessage = "The field email is required"), EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The field password is required")]
    public string Password { get; set; }
}