using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TB.EmailSubscriber.Models;

namespace TB.EmailSubscriber.Persistence
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptions();
        Task<Subscription> GetSubscription(int id);
        Task<Subscription> GetSubscription(string token);
        void Subscribe(Subscription subscription);
        void Unsubscribe(string token);
        bool SubscriptionExist(string email);
    }
}
