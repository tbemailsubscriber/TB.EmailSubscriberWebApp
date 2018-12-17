using System;
using System.Collections.Generic;
using System.Text;

namespace TB.EmailSubscriber.Models
{
    public class SubscribtionTopic
    {
            public int SubscriptionId { get; set; }

            public int TopicId { get; set; }

            public Subscription Subscription { get; set; }

            public Topic Topic { get; set; }
    }
}
