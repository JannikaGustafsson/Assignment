using Business.Interfaces;
using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Console_MainApp.Dtos;

public class UserRegistrationForm
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must contain at least two characters")]

    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$", ErrorMessage = "Email must be in a valid format such as: example@domain.com")]
    public string Email { get; set; }= null!;
}





