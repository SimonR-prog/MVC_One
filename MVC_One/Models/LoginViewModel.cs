using System.ComponentModel.DataAnnotations;

namespace MVC_One.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Keep me logged in.")]
    public bool RememberMe { get; set; }
}
