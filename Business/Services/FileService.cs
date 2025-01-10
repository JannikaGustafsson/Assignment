using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;


/// <summary>
/// This is an abstract class for file handling that manages file reading and writing.
/// </summary>
public abstract class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;


    //Chat gpt generated comment
    /// <summary>
    /// Initializes a new instance of the FileService class with specified directory and file name.
    /// </summary>
 
    public FileService(string directoryPath, string fileName)
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }


    /// <summary>
    /// The directorypath where the file is located.
    /// </summary>
    public string? DirectoryPath { get; internal set; }


    /// <summary>
    /// Gets the content of file as string.
    /// </summary>
    /// <returns>The content or null if the file doesn't exist.</returns>
    public virtual string GetContentFromFile()
    {
        if (File.Exists(_filePath))
            return File.ReadAllText(_filePath);

        return null!;        
    }

    /// <summary>
    /// Saves the userRegistrationsForm to a file.
    /// </summary>
    /// <returns>True if it was saved successfully, otherwise false value.</returns>
  
    public bool Save(UserRegistrationForm userRegistrationForm)
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

    /// <summary>
    /// Saves the content to a file at the file path provided
    /// </summary>
    /// <returns>True value if the content was saved successfully, otherwise false value.</returns>
    public virtual bool SaveContentToFile(string content)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving content to file: {ex.Message}");
            return false;
        }
    }
}
