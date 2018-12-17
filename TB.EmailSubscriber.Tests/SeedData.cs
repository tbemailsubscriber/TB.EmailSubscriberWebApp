using System;
using System.Collections.Generic;
using System.Text;
using TB.EmailSubscriber.Models;
using TB.EmailSubscriber.Persistence;

namespace TB.EmailSubscriber.Tests
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            dbContext.Subscriptions.Add(new Subscription() { Id = 1, Email="test@test.com", UniqueToken="QWERTY123456" });
            dbContext.Topics.Add(new Topic() { Id = 1, Name = "Topic1" });
            dbContext.SaveChanges();
        }
    }
}