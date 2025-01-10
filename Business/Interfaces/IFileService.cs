using Business.Models;

namespace Business.Interfaces;

public interface IFileService : IFileReader, IFileWriter
{

    /// <summary>
    /// This saves the UserRegistrationForm to a file.
    /// </summary>///
    /// <returns>A value of true if the form was created successfully, otherwise a value of false.</returns>
    bool Save(UserRegistrationForm userRegistrationForm);
}
