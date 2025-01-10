namespace Business.Interfaces;

public interface IFileWriter
{

    /// <summary>
    /// This saves the given content to a file.
    /// </summary>
    /// <returns>A value of true if the content was created successfully, otherwise a value of false.</returns>
    bool SaveContentToFile(string content);
}
