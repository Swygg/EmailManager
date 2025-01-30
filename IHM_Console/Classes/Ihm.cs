using BLL.Classes;
using BLL.Interfaces;
using IHM_Console.Interfaces;
using MODELS;

namespace IHM_Console.Classes
{
    public class Ihm : IIhm
    {
        private IHostersBllManager _hosterBllManager;
        private IEmailAccountsBllManager _emailAccountsBllManager;
        public Ihm(IHostersBllManager hosterBllManager, 
            IEmailAccountsBllManager emailAccountsBllManager)
        {

            _hosterBllManager = hosterBllManager;
            _emailAccountsBllManager = emailAccountsBllManager;

            //Mock Hosters
            var hosters = new List<Hoster>()
            {
                new Hoster("LaPoste.net", "imap.laposte.net", 993, "smtp.laposte.net", 465),
                new Hoster("Gmail",  "imap.gmail.com", 993, "smtp.gmail.com", 465),
                new Hoster("Outlook.com", "imap-mail.outlook.com", 993, "smtp-mail.outlook.com", 587),
                new Hoster("Hotmail.com",  "imap-mail.outlook.com", 993, "smtp-mail.outlook.com", 587),
                new Hoster("Hotmail.fr", "imap-mail.outlook.com", 993, "smtp-mail.outlook.com", 587),
            };
            foreach (var hoster in hosters)
            {
                _hosterBllManager.Add(hoster);
            }

            //Mock EmailAccount
            var emailAccounts = new List<EmailAccount>()
            {
                new EmailAccount("toto1@laposte.net", "123"),
                new EmailAccount("toto2@hotmail.com", "123"),
                new EmailAccount("toto3@hotmail.fr", "123"),
            };
            foreach (var emailAccount in emailAccounts)
            {
                _emailAccountsBllManager.Add(emailAccount);
            }
        }

        public void GetHostersList()
        {
            var hosters = _hosterBllManager.GetAll()
                    .OrderBy(x => x.Name)
                    .ToList();

            Console.WriteLine("=== Hosters ===");
            foreach (var hoster in hosters)
            {
                DescribeHoster(hoster);
            }
        }

        public void GetEmailAccountsList()
        {
            var emailAccounts = _emailAccountsBllManager.GetAll();
            Console.WriteLine("===Email Accounts===");
            foreach (var emailAccount in emailAccounts)
            {
                DescribeEmailAccount(emailAccount);
            }
        }

        private void DescribeHoster(Hoster hoster)
        {
            Console.WriteLine($"{hoster.Name} - Imap = ({hoster.ServerImap}/{hoster.PortIMAP})");
        }

        private void DescribeEmailAccount(EmailAccount emailAccount)
        {
            Console.WriteLine($"{emailAccount.Login}");
        }
    }
}
