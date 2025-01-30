using DAL.Interfaces;
using MODELS;

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
            var host = _hostersDalManager.GetOne(emailAccount.Hoster);
            return new List<Email>();
        }
    }
}
