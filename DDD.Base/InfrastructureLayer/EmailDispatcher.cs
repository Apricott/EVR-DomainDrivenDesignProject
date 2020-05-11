using DDD.Base.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace DDD.Base.InfrastructureLayer
{
    public class EmailDispatcher : IEmailDispatcher
    {
        public void Send(MailMessage mailMessage)
        {
            // put email sending code here ...
        }
    }
}
