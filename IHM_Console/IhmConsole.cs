using IHM_Console.Helpers;
using IHM_Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MODELS;
using System;

namespace IHM_Console
{
    public class IhmConsole
    {
        ICollection<EmailAccount> emailAccounts;
        ServiceProvider _serviceProvider;

        public IhmConsole()
        {
            _serviceProvider = DependencyInjectionHelper.GetServiceProvider();
            var config = new ConfigurationBuilder()
                        .SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddUserSecrets<Program>()
                        .Build();

            // Récupération des données cachées
            emailAccounts = config.GetSection("EmailAccountsSettings").Get<List<EmailAccount>>();
        }

        public void ListerMails()
        {
            // Résolution et utilisation du service
            var ihm = _serviceProvider.GetRequiredService<IIhm>();
            foreach (var emailAccount in emailAccounts)
            {
                Console.WriteLine($"Tentative de connexion à {emailAccount.Login}");
                var emails = ihm.GetEmails(emailAccount);
                foreach (var email in emails)
                {
                    Console.WriteLine(email.Title);
                }
            }
        }
    }
}
