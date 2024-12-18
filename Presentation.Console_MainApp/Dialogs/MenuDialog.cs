using System.ComponentModel.DataAnnotations;
using Business.Factories;
using Business.Interfaces;
using Presentation.Console_MainApp.Dtos;
using Business.Models;
using Business.Services;

namespace Presentation.Console_MainApp.Dialogs;

public class MenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;


    public void UserRegistrationDialog()
    {
        var urf = new UserRegistrationForm();

        urf.Name = PromptAndValidate("Enter your name: ", nameof(urf.Name));
        urf.Email = PromptAndValidate("Enter your Email: ", nameof(urf.Email));

        Console.WriteLine("User registration was successful!");
        Console.ReadKey();
    }

    public string PromptAndValidate(string prompt, string propertyName)
    {
        while (true){
            Console.WriteLine();
            Console.Write(prompt);
            var input = Console.ReadLine() ?? string.Empty;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(new UserRegistrationForm()) { MemberName = propertyName };

            if (Validator.TryValidateProperty(input, context, results))
                return input;

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
        var contact = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("----------ADD NEW CONTACT----------");
        Console.WriteLine("Enter Your Name: ");
        contact.Name = Console.ReadLine()!;

        var result = _contactService.CreateContact(contact);
        if (result)
            Console.WriteLine("contact was created successfully!");
        else
            Console.WriteLine("Unable to create new contact.");

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
