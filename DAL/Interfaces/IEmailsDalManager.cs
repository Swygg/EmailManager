using MODELS;

namespace DAL.Interfaces
{
    public interface IEmailsDalManager
    {
        ICollection<Email> GetEmails(EmailAccount emailAccount);
    }
}
