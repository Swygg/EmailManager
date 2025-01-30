// See https://aka.ms/new-console-template for more information
using IHM_Console.Helpers;
using IHM_Console.Interfaces;
using MailKit;
using MailKit.Net.Imap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = DependencyInjectionHelper.GetServiceProvider();

// Résolution et utilisation du service
var ihm = serviceProvider.GetRequiredService<IIhm>();
//ihm.GetHostersList();
//ihm.GetEmailAccountsList();
ihm.GetEmailsFromAccounts();



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





Console.WriteLine("Test email");

string host = "imap.laposte.net"; // Serveur IMAP de Laposte
int port = 993; // Port sécurisé IMAP
string username = "";
string password = "";

using var client = new ImapClient();
client.Connect(host, port, MailKit.Security.SecureSocketOptions.SslOnConnect);
try
{
    client.Authenticate(username, password);

    var inbox = client.Inbox;
    inbox.Open(FolderAccess.ReadOnly);

    int count = inbox.Count;
    int startIndex = Math.Max(count - 30, 0); // Récupère les 30 derniers e-mails

    for (int i = count - 1; i >= startIndex; i--)
    {
        var message = inbox.GetMessage(i);
        Console.WriteLine($" {message.Date}: {message.Subject}");
    }
    client.Disconnect(true);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}