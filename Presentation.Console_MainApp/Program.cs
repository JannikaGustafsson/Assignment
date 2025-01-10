using Business.Interfaces;
using Business.Repositories;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Console_MainApp.Dialogs;



var ServiceProvider = new ServiceCollection()
    .AddSingleton<IUserFileService>(sp => new UserFileService("Data", "contacts.json"))
    .AddScoped<IContactRepository, ContactRepository>()
    .AddScoped<IContactService, ContactService>()
    .AddScoped<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = ServiceProvider.GetRequiredService<MenuDialog>();
menuDialog.MainMenu();
