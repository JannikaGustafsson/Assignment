using System.Diagnostics;
using System.Text.Json;
using Business.Factories;
using Business.Interfaces;
using Business.Models;


namespace Business.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly IUserFileService _fileService;


    /// <summary>
    /// Initializes a instance of the ContactRepository with file service.
    /// </summary>

    public ContactRepository(IUserFileService fileService)
    {
        _fileService = fileService;
    }


    /// <summary>
    /// Retrieves a list of contacts from a file.
    /// </summary>
    /// <returns>A list of Contact objects.</returns>
    public List<Contact> GetContacts()
    {
        try
        {
            var json = _fileService.GetContentFromFile();
            
            var contactEntities = JsonSerializer.Deserialize<List<ContactEntity>>(json);

            if (contactEntities == null || contactEntities.Count == 0)
            {
                return [];
            }
            var contacts = new List<Contact>();
            foreach (var entity in contactEntities)
            {
                var contact = ContactFactory.Create(entity);
                if (contact != null)
                {
                    contacts.Add(contact); 
                }
            }

            return contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            return [];
        }  
    }


    /// <summary>
    /// Saves a list of contacts to a file.
    /// </summary>
    /// <returns>A value of true if the contact was saved successfully, otherwise a value of false.</returns>
    public bool SaveContacts(List<ContactEntity> contacts)
    {
        try
        {
            var contactEntities = contacts.Select(contact => new ContactEntity
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email
            }).ToList();

            return SaveToFile(contactEntities);
        }
        catch (Exception ex)
        {
        Debug.WriteLine($"Error: {ex.Message}");
        return false;

        }        
    }


    /// <summary>
    /// Saves the list of contact entities to a json file.
    /// </summary>
    /// <returns>True if the list was created successfully, otherwise a false value.</returns>
    public bool SaveToFile(List<ContactEntity> list)
    {
        try
        {
            var json = JsonSerializer.Serialize(list);
            _fileService.SaveContentToFile(json);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            return false;
        }                
    }

}


