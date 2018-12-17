using System.Net.Mail;

namespace TB.EmailSubscriber.EmailDistributor
{
    public static class EmailBuilder
    {
        public static MailMessage BuildSubscribeMessage(string emailAddress, string[] topics, string unsubscribeLink)
        {
            string body = "Thank you for subscribing our services<br /> Topics subscribed: <br />";
            foreach (var topic in topics)
            {
                body += " " + topic + "<br />";
            }
            body += "To unsubscribe from our services plese click a link below: <br/>";
            body += unsubscribeLink;
            MailMessage message = new MailMessage("subscription.services@tb.com", emailAddress, "Subscribe confirmation", body)
            {
                IsBodyHtml = true
            };
            return message;
        }

        internal static MailMessage BuildUnsubscribeMessage(string emailAddress)
        {
            return new MailMessage("subscription.services@tb.com", emailAddress, "Unsubscribe confirmation", "You have successfully unsubscribe from our services.");
        }
    }
}
