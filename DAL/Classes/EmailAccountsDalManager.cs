using DAL.Interfaces;
using MODELS;

namespace DAL.Classes
{
    public class EmailAccountsDalManager : IEmailAccountsDalManager
    {
        private List<EmailAccount> _emailAccounts = new List<EmailAccount>();

        public ICollection<EmailAccount> GetAll()
        {
            return _emailAccounts;
        }

        public EmailAccount? GetOne(string email)
        {
          return _emailAccounts.FirstOrDefault(x=> x.Login.ToLower() == email.ToLower());
        }

        public void Add(EmailAccount account)
        {
            var existingAccount = GetOne(account.Login);
            if (existingAccount != null)
                throw new Exception("Compte déjà existant");

            _emailAccounts.Add(account);
        }

        public void Update(string email, EmailAccount account)
        {
            var existingAccount = GetOne(email);
            if (existingAccount == null)
                throw new Exception("Compte inexistant");

            existingAccount.Login = account.Login;
            existingAccount.Password = account.Password;
        }

        public void Remove(string email)
        {
            var index = _emailAccounts.ToList().FindIndex(x => x.Login.ToLower() == email.ToLower());
            if (index == -1)
                throw new Exception("L'index n'existe pas.");

            _emailAccounts.RemoveAt(index);
        }
    }
}
