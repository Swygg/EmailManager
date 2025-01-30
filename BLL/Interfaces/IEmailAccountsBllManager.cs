using MODELS;

namespace BLL.Interfaces
{
    public interface IEmailAccountsBllManager
    {
        ICollection<EmailAccount> GetAll();
        EmailAccount? GetOne(string email);
        void Add(EmailAccount account);
        void Update(string email, EmailAccount account);
        void Remove(string email);
    }
}
