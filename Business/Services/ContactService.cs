using System.Diagnostics;
using System.Text.Json;
using Business.Factories;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService(IContactRepository contactRepository, IUserFileService userFileService) : IContactService
{
    private readonly IContactRepository _contactRepository = contactRepository;
    private readonly IUserFileService _userFileService = userFileService;
    private readonly List<ContactEntity> _contact = [];


    /// <summary>
    /// Creates a new contact based on userRegistrationform.
    /// </summary>
    /// <returns>True if the contact was created and saved successfully, otherwise false value.</returns>
    public bool CreateContact(UserRegistrationForm contact)
    {
        try
        {
            var contactEntity = ContactFactory.Create(contact);
            contactEntity!.Id = IdGenerator.GenerateUniqueId();

            _contact.Add(contactEntity);

            var result = _contactRepository.SaveContacts(_contact);
            
            if (result)
            {
                var json = JsonSerializer.Serialize(_contact);
                _userFileService.SaveContentToFile(json);

            }         

            return result;
        }
        catch (Exception ex) 
        {
            Debug.WriteLine($"Error creating contact: {ex.Message}");
            return false;
        }
    }


    /// <summary>
    /// Gets all contacts from the repository.
    /// </summary>
    public IEnumerable<Contact> GetAllContacts()
    {
        var contacts = _contactRepository.GetContacts();
        return contacts ?? [];
        
    }

}
