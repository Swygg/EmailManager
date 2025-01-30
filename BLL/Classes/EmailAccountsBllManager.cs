using BLL.Interfaces;
using DAL.Interfaces;
using MODELS;

namespace BLL.Classes
{
    public class EmailAccountsBllManager : IEmailAccountsBllManager
    {
        private IEmailAccountsDalManager _emailAccountsDalManager;
        public EmailAccountsBllManager(IEmailAccountsDalManager emailAccountsDalManager) {
            _emailAccountsDalManager = emailAccountsDalManager;
        }

        public ICollection<EmailAccount> GetAll()
        {
           return _emailAccountsDalManager.GetAll();
        }

        public EmailAccount? GetOne(string email)
        {
            return _emailAccountsDalManager.GetOne(email);
        }

        public void Add(EmailAccount account)
        {
            _emailAccountsDalManager.Add(account);
        }

        public void Update(string email, EmailAccount account)
        {
            _emailAccountsDalManager.Update(email, account);
        }

        public void Remove(string email)
        {
            _emailAccountsDalManager.Remove(email);
        }
    }
}
