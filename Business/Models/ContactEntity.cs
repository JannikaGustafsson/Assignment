namespace Business.Models;

public class ContactEntity
{

    /// <summary>
    /// The unique id of the contact.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// The first name of the contact.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// The last name of the contact.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// The email address for the contact.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// The Secured Password
    /// </summary>
    public string SecuredPassword { get; set; } = null!;

    /// <summary>
    /// The secured key
    /// </summary>
    public string SecuredKey { get; set; } = null!;

}
