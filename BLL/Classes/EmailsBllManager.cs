using BLL.Interfaces;
using DAL.Interfaces;
using MODELS;

namespace BLL.Classes
{
    public class EmailsBllManager : IEmailsBllManager
    {
        private IEmailsDalManager _emailsDalManager;

        public EmailsBllManager(IEmailsDalManager emailsDalManager)
        {
            _emailsDalManager = emailsDalManager;
        }

        public ICollection<Email> GetEmails(EmailAccount emailAccount)
        {
           return _emailsDalManager.GetEmails(emailAccount);
        }
    }
}
