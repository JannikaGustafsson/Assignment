using Business.Interfaces;
using Business.Repositories;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Console_MainApp.Dialogs;



var ServiceProvider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("Data", "contacts.json"))
    .AddSingleton<IContactRepository, ContactRepository>()
    .AddSingleton<IContactService, ContactService>()
    .AddTransient<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = ServiceProvider.GetRequiredService<MenuDialog>();
menuDialog.MainMenu();


