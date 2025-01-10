namespace Business.Models;

public class Contact
{
    /// <summary>
    /// The unique id of the contact.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// The name of the contact.
    /// </summary>
    public string Name { get; set; } = null!;


    /// <summary>
    /// The email address for the contact.
    /// </summary>
    public string Email { get; set; } = null!;
}
