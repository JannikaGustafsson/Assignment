using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{

    /// <summary>
    /// This creates a new contact using UserRegistrationForm.
    /// </summary>
    /// <returns>A value of true if the contact was created successfully, otherwise a value of false.</returns>
    bool CreateContact(UserRegistrationForm contact);


    /// <summary>
    /// This gets the contacts.
    /// </summary>
    /// <returns>A collection of contact objects.</returns>
    IEnumerable<Contact> GetAllContacts();
}
