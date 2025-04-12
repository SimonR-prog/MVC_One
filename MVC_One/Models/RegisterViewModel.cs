using System.ComponentModel.DataAnnotations;

namespace MVC_One.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address.")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{10,}$", ErrorMessage = "Invalid password.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password.")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password", Prompt = "Re-enter your password.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    [Range(typeof(bool), "true", "true")]
    public bool TermsAndConditions { get; set; }
}
