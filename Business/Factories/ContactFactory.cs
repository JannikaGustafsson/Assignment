using System.Diagnostics;
using Business.Models;

namespace Business.Factories;


public static class ContactFactory
{
    /// <summary>
    /// This Creates a new UserRegistrationForm.
    /// </summary>
    /// <returns>A new UserRegistrationForm object.</returns>
    public static UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }

    /// <summary>
    /// This creates a ContactEntity from the information in the UserRegistrationForm.
    /// </summary>
    /// <returns>A Contactentity with the user's name and email.</returns>
    public static ContactEntity? Create(UserRegistrationForm form)
    {
        try
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form), "UserRegistrationForm can't be null");
           
            return new ContactEntity
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating ContactEntity: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// This creates a contact from the ContactEntity.
    /// </summary>
    /// <returns>A Contact with the user's name and email.</returns>
    public static Contact? Create(ContactEntity entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "ContactEntity can't be null");

            return new Contact
            {
                Id = entity.Id,
                Name = $"{entity.FirstName} {entity.LastName}",
                Email = entity.Email
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating contact: {ex.Message}");
            return null;
        }
    }
}


