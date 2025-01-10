using Business.Models;

namespace Business.Interfaces;

public interface IContactRepository
{
    /// <summary>
    /// This gets a list of all the contacts.
    /// </summary>
    /// <returns>A list of Contact objects.</returns>
    List<Contact> GetContacts();

    /// <summary>
    /// This saves a list of contacts.
    /// </summary>
    bool SaveContacts(List<ContactEntity> contacts);
}
