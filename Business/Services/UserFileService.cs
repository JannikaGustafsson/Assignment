using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using Business.Models;


namespace Business.Services;

/// <summary>
/// This is a service for handling user files, inheriting from FileService.
/// </summary>
public class UserFileService : FileService, IUserFileService
{


    //Chat gpt generated comment
    /// <summary>
    /// Initializes a new instance of the UserFileService class with the specified directory path and file name.
    /// </summary>
    /// <param name="directoryPath">The directory path for storing user files.</param>
    /// <param name="fileName">The file name for the user file.</param>
    public UserFileService(string directoryPath, string fileName) : base(directoryPath, fileName)
    {
    }

/// <summary>
/// This is a service for handling user files, inheriting from FileService.
/// </summary>


    bool IUserFileService.Save(UserRegistrationForm userRegistrationForm)
    {
        try
        {
            var json = JsonSerializer.Serialize(userRegistrationForm);
            return SaveContentToFile(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving userRegistrationForm: {ex.Message}");
            return false;
        }
    }

    bool IFileService.Save(UserRegistrationForm userRegistrationForm)
    {
        try
        {
            var json = JsonSerializer.Serialize(userRegistrationForm);
            return SaveContentToFile(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving userRegistrationForm: {ex.Message}");
            return false;
        }
    }
}






//public class UserFileService(string directoryPath, string fileName) : FileService(directoryPath, fileName), IFileService
