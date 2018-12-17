using System;
using System.Collections.Generic;
using System.Text;

namespace TB.EmailSubscriber.EmailDistributor
{
    public interface IEmailSender
    {
         void SendConfirmation(string email, string unsubscribeToken, string[] topics);
         void SendUnsubscribeConfirmation(string emailAddress);
    }
}
