using Business.Models;

namespace Business.Interfaces;

public interface IUserFileService : IFileService
{

    /// <summary>
    /// This saves the user registration form to a file.
    /// </summary>
    /// <returns>A value of true if the UserRegistrationForm was created successfully, otherwise a value of false.</returns>
    bool Save(UserRegistrationForm userRegistrationForm);
}
