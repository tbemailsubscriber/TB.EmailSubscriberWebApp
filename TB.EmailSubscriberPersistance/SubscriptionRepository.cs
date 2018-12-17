using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TB.EmailSubscriber.Models;

namespace TB.EmailSubscriber.Persistence
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _persistence;

        public SubscriptionRepository(AppDbContext persistance)
        {
            this._persistence  = persistance;
        }

        public bool SubscriptionExist(string email)
        {
            var subscription = _persistence.Subscriptions.FirstOrDefault(s=> s.Email==email);
            return subscription != null;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptions()
        {
            return await _persistence.Subscriptions
                .Include(s => s.Topics)
                .ThenInclude(st => st.Topic).ToListAsync();
        }

        public async Task<Subscription> GetSubscription(int id)
        {
            return await _persistence.Subscriptions
                .Include(s => s.Topics)
                .ThenInclude(st => st.Topic)
              .SingleOrDefaultAsync(s => s.Id == id); 
        }
                
        public async Task<Subscription> GetSubscription(string token)
        {
            return await _persistence.Subscriptions
                .Include(s => s.Topics)
                .ThenInclude(st => st.Topic)
              .SingleOrDefaultAsync(s => s.UniqueToken == token); 
        }

        public void Subscribe( Subscription subscription)
        {
             _persistence.Subscriptions.AddAsync(subscription);
        }

        public void Unsubscribe(string token)
        {
            var subscription = _persistence.Subscriptions.SingleOrDefaultAsync(s => s.UniqueToken == token);
            if (subscription != null)
            {
               _persistence.Subscriptions.Remove(subscription.Result);
            }
            else
            {

            }
        }
    }
}
