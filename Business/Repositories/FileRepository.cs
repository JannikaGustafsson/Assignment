using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using Business.Models;

namespace Business.Repositories;

public abstract class BaseRepository<TEntity>
{

    /// <summary>
    /// An Abstract method to save a list of entities to file.
    /// </summary>
    public abstract bool SaveToFile(List<TEntity> list);

    /// <summary>
    /// Abstract method to get entities from a file.
    /// </summary>
    public abstract IEnumerable<TEntity> GetFromFile();

    /// <summary>
    /// Serializes a list of entities to JSON string.
    /// </summary>
    public virtual string Serialize(List<TEntity> list)
    {
        return JsonSerializer.Serialize(list);
    }

    /// <summary>
    /// Deserializes a JSON string to a list of entities.
    /// </summary>
    public virtual List<TEntity> Deserialize(string json)
    {
        return JsonSerializer.Deserialize<List<TEntity>>(json) ?? new List<TEntity>();
    }

}
public class FileRepository : BaseRepository<ContactEntity>
{
    private readonly IUserFileService _userFileService;



    /// <summary>
    /// Initializes a new instance of the FileRepository class with the file service.
    /// </summary>
    public FileRepository(IUserFileService userFileService)
    {
        _userFileService = userFileService;
    }


    /// <summary>
    /// Gets list of ContactEntity objects from a file.
    /// </summary>
    /// <returns>A list of ContactEntity objects.</returns>
    public override IEnumerable<ContactEntity> GetFromFile()
    {
        try
        {
            var json = _userFileService.GetContentFromFile();
            var list = JsonSerializer.Deserialize<List<ContactEntity>>(json);
            return list ?? [];
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deserializing file: {ex.Message}");
            return Enumerable.Empty<ContactEntity>();
        }
    }


    /// <summary>
    /// Saves list of ContactEntity objects to file.
    /// </summary>
    /// <returns>True if entity was saved successfully, otherwise false value</returns>
    public override bool SaveToFile(List<ContactEntity> list)
    {
        try
        {
            var json = JsonSerializer.Serialize(list);
            _userFileService.SaveContentToFile(json);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            return false;
        }

    }
}

