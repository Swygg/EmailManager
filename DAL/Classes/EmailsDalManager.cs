using DAL.Interfaces;
using MailKit;
using MailKit.Net.Imap;
using MODELS;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Classes
{
    public class EmailsDalManager : IEmailsDalManager
    {
        private IHostersDalManager _hostersDalManager;

        public EmailsDalManager(IHostersDalManager hostersDalManager)
        {
            _hostersDalManager = hostersDalManager;
        }

        public ICollection<Email> GetEmails(EmailAccount emailAccount)
        {
            var results = new List<Email>();

            var hoster = _hostersDalManager.GetOne(emailAccount.Hoster);
            if (hoster == null)
                throw new Exception($"Aucun hoster connu pour {emailAccount.Hoster}");

            using var client = new ImapClient();
            try
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(hoster.ServerIMAP, hoster.PortIMAP, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(emailAccount.Login, emailAccount.Password);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                int count = inbox.Count;
                int startIndex = Math.Max(count - 30, 0); // Récupère les 30 derniers e-mails

                for (int i = count - 1; i >= startIndex; i--)
                {
                    var message = inbox.GetMessage(i);
                    var mail = new Email()
                    {
                        Title = message.Subject,
                        Date = message.Date.UtcDateTime,
                    };
                    results.Add(mail);
                }
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return results;
        }
    }
}
