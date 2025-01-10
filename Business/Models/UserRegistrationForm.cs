using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class UserRegistrationForm
{
    /// <summary>
    /// Applicates regular expressions for the user when typing first name, last name, email and password it also generates an error message to guide the user. Validates the questions asked in MenuDialog.
    /// </summary>

    [Required(ErrorMessage = "First Name is required")]
    [MinLength(2, ErrorMessage = "First Name must contain at least two characters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last Name is required")]
    [MinLength(2, ErrorMessage = "LastName must contain at least two characters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$", ErrorMessage = "Email must be in a valid format such as: example@domain.com")]
    public string Email { get; set; }= null!;
    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; } = null!;
    [Required]
    [Compare(nameof(Password))]
    public string PasswordConfirmation { get; set; } = null!;
}





