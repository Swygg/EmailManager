using BLL.Interfaces;
using IHM_Console.Interfaces;
using MODELS;

namespace IHM_Console.Classes
{
    public class Ihm : IIhm
    {
        private IHostersBllManager _hosterBllManager;
        private IEmailAccountsBllManager _emailAccountsBllManager;
        private IEmailsBllManager _emailsBllManager;
        public Ihm(IHostersBllManager hosterBllManager,
            IEmailAccountsBllManager emailAccountsBllManager,
            IEmailsBllManager emailsBllManager)
        {

            _hosterBllManager = hosterBllManager;
            _emailAccountsBllManager = emailAccountsBllManager;
            _emailsBllManager = emailsBllManager;

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

        public void GetEmailsFromAccounts()
        {
            var emailAccounts = _emailAccountsBllManager.GetAll();
            foreach (var emailAccount in emailAccounts)
            {
                Console.WriteLine($"Email : {emailAccount.Login}");
                try
                {
                    var emails = _emailsBllManager.GetEmails(emailAccount);
                    Console.WriteLine($"Nombre emails : {emails.Count}");
                    foreach (var email in emails)
                    {
                        DescribeEmail(email);
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void DescribeHoster(Hoster hoster)
        {
            Console.WriteLine($"{hoster.Name} - Imap = ({hoster.ServerIMAP}/{hoster.PortIMAP})");
        }

        private void DescribeEmailAccount(EmailAccount emailAccount)
        {
            Console.WriteLine($"{emailAccount.Login}");
        }

        private void DescribeEmail(Email email)
        {
            Console.WriteLine($"{email.Date.ToString("dd/MM/yyyy")} - {email.Title}");
        }
    }
}
