using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TB.EmailSubscriber.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UniqueToken { get; set; }
        public DateTime SubscribeDate { get; set; }
        
        public ICollection<SubscribtionTopic> Topics { get; set; }

        public Subscription()
        {
            Topics = new Collection<SubscribtionTopic>();
        }
    }

    public class SubscriptionResource
    {
        public String Email { get; set; }
        public ICollection<int> Topics { get; set; }

        public SubscriptionResource()
        {
            Topics = new Collection<int>();
        }
    }
}
