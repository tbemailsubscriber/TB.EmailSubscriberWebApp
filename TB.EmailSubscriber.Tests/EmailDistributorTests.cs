using System;
using System.Net.Mail;
using TB.EmailSubscriber.EmailDistributor;
using Xunit;

namespace TB.EmailSubscriber.Tests
{
    public class EmailDistributorTests
    {
        static string toEmail = "tomasz@test.com";
        MailMessage mail = EmailBuilder.BuildSubscribeMessage(toEmail, new string[] { "topic1", "topic2" }, "LinToUnsubscribe");

        [Fact]
        public void ShouldValidateEmailTrue()
        {
            Assert.True(EmailValidator.IsValidEmail("test.test@test.com"));
        }

        [Fact]
        public void ShouldValidateEmailFalse()
        {

            Assert.False(EmailValidator.IsValidEmail("test.testtest.com"));
        }

        [Fact]
        public void ShouldEmailAddressBeSet()
        {
            Assert.Equal( toEmail, mail.To.ToString());
        }

        [Fact]
        public void ShouldEmailIncludeTopics()
        {
            Assert.Contains("topic1", mail.Body);
        }

        [Fact]
        public void ShouldEmailIncludeUnsubscribeLink()
        {
            string unsubscribeLink = "LinToUnsubscribe";
            Assert.Contains(unsubscribeLink, mail.Body);
        }

    }
}
