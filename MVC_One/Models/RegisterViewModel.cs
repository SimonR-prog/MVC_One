using System.ComponentModel.DataAnnotations;

namespace MVC_One.Models;

public class RegisterViewModel
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public string ConfirmPassword { get; set; } = null!;

    [Required]
    public bool TermsAndConditions { get; set; }
}
