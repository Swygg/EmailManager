using MODELS;

namespace BLL.Interfaces
{
    public interface IEmailsBllManager
    {
        ICollection<Email> GetEmails(EmailAccount emailAccount);
    }
}
