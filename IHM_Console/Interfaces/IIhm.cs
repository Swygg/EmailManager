using MODELS;

namespace IHM_Console.Interfaces
{
    public interface IIhm
    {
        //IHM only
        void GetHostersList();
        void GetEmailAccountsList();
        void GetEmailsFromAccounts();


        //EmailAccount management
        ICollection<EmailAccount> GetAllEmailAccount();
        EmailAccount? GetOneEmailAccount(string email);
        void AddEmailAccount(EmailAccount account);
        void UpdateEmailAccount(string email, EmailAccount account);
        void RemoveEmailAccount(string email);

        //Emails management
        ICollection<Email> GetEmails(EmailAccount emailAccount);

        //Hosters management
        ICollection<Hoster> GetAllHoster();
        Hoster? GetOneHoster(string name);
        void AddHoster(Hoster hoster);
        public void UpdateHoster(string name, Hoster input);
        void RemoveHoster(string name);
    }
}
