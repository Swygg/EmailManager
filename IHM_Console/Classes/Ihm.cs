using BLL.Interfaces;
using IHM_Console.Interfaces;
using MODELS;

namespace IHM_Console.Classes
{
    public class Ihm : IIhm
    {
        private IHosterBllManager _hosterBllManager;
        public Ihm(IHosterBllManager hosterBllManager)
        {

            _hosterBllManager = hosterBllManager;

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
        }

        public void GetHostersList()
        {
            var hosters = _hosterBllManager.GetAll()
                    .OrderBy(x => x.Name)
                    .ToList();

            foreach (var hoster in hosters)
            {
                DescribeHoster(hoster);
            }
        }

        private void DescribeHoster(Hoster hoster)
        {
            Console.WriteLine($"{hoster.Name} - Imap = ({hoster.ServerImap}/{hoster.PortIMAP})");
        }
    }
}
