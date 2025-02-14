// See https://aka.ms/new-console-template for more information
using IHM_Console.Helpers;
using IHM_Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = DependencyInjectionHelper.GetServiceProvider();

// Résolution et utilisation du service
var ihm = serviceProvider.GetRequiredService<IIhm>();
ihm.GetHostersList();
ihm.GetEmailAccountsList();
ihm.GetEmailsFromAccounts();


//Console.ReadKey();

return;
var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .Build();







//// Lire les comptes email sous forme de liste
//var emailAccounts = config.GetSection("EmailAccountsSettings").Get<List<Account>>();
//
//// Afficher les comptes
//foreach (var account in emailAccounts)
//{
//    Console.WriteLine($"Login: {account.Login}, Password: {account.Password}");
//}



