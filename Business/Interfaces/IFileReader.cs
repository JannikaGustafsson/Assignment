namespace Business.Interfaces;

public interface IFileReader
{
    /// <summary>
    /// This gets the content from a file.
    /// </summary>
    /// <returns>The content of the file as a string.</returns>
    string GetContentFromFile();
}
