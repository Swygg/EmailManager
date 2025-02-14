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

        #region IHM
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
                catch (Exception ex)
                {
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
        #endregion



        #region EmailAccount management
        public ICollection<EmailAccount> GetAllEmailAccount()
        {
            return _emailAccountsBllManager.GetAll();
        }
        public EmailAccount? GetOneEmailAccount(string email)
        {
            return _emailAccountsBllManager.GetOne(email);
        }
        public void AddEmailAccount(EmailAccount account)
        {
            _emailAccountsBllManager.Add(account);
        }
        public void UpdateEmailAccount(string email, EmailAccount account)
        {
            _emailAccountsBllManager.Update(email, account);
        }
        public void RemoveEmailAccount(string email)
        {
            _emailAccountsBllManager.Remove(email);
        }
        #endregion


        #region Emails management
        public ICollection<Email> GetEmails(EmailAccount emailAccount)
        {
            return _emailsBllManager.GetEmails(emailAccount);
        }
        #endregion


        #region Hosters management
        public ICollection<Hoster> GetAllHoster()
        {
            return _hosterBllManager.GetAll();
        }
        public Hoster? GetOneHoster(string name)
        {
            return _hosterBllManager.GetOne(name);
        }
        public void AddHoster(Hoster hoster)
        {
            _hosterBllManager.Add(hoster);
        }
        public void UpdateHoster(string name, Hoster input)
        {
            _hosterBllManager.Update(name, input);
        }
        public void RemoveHoster(string name)
        {
            _hosterBllManager.Remove(name);
        }
        #endregion
    }
}
