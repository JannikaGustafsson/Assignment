using System.ComponentModel.DataAnnotations;
using Business.Factories;
using Business.Interfaces;
using Business.Models;


namespace Presentation.Console_MainApp.Dialogs;

public class MenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;


    public string PromptAndValidate(string prompt, string propertyName, UserRegistrationForm contact)
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write(prompt);

            var input = Console.ReadLine() ?? string.Empty;
            var property = contact.GetType().GetProperty(propertyName);

            if (property == null)
            {
                Console.WriteLine($"Property '{propertyName}' does not exist on {contact.GetType().Name}. Please check the property name.");
                return string.Empty;
            }
                property.SetValue(contact, input);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(contact) { MemberName = propertyName };

            if (Validator.TryValidateProperty(property.GetValue(contact), context, results))
            {

                return input;
            }

            Console.WriteLine($"{results[0].ErrorMessage}. Please try again.");
        }

    }

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------MAIN MENU----------");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.Write("Select option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddNewContact();
                    break;

                    case "2":
                    ViewAllContacts();
                    break;
            }
        }
    }
    public void AddNewContact()
    {
        var form = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("----------ADD NEW CONTACT----------");

        form.FirstName = PromptAndValidate("Enter your first name: ", nameof(form.FirstName), form);
        form.LastName = PromptAndValidate("Enter your last name: ", nameof(form.LastName), form);
        form.Email = PromptAndValidate("Enter your Email: ", nameof(form.Email), form);

        var isSucceeded = _contactService.CreateContact(form);

        if (isSucceeded)
        {
            Console.WriteLine("User registration was successful!");
        }
        else
        {
            Console.WriteLine("Unable to create new contact.");
        }

        Console.ReadKey();
    }

    public void ViewAllContacts()
    {
        Console.Clear();
        Console.WriteLine("----------VIEW ALL CONTACTS----------");

        foreach (var contact in _contactService.GetAllContacts())
            Console.WriteLine($"{contact.Name} ({contact.Id})");
        Console.ReadKey();
    }
}
