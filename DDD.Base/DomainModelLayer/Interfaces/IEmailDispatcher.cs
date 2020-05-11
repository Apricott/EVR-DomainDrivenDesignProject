using System.Net.Mail;
using System.Text;

namespace DDD.Base.DomainModelLayer.Interfaces
{
    public interface IEmailDispatcher
    {
        void Send(MailMessage mailMessage);
    }
}
