using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TB.EmailSubscriber.Models;

namespace TB.EmailSubscriber.Persistence
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _persistence;

        public TopicRepository(AppDbContext persistance)
        {
            this._persistence = persistance;
        }

        public async Task<Topic> GetTopic(int id)
        {
            return await _persistence.Topics.FindAsync(id);
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            return await _persistence.Topics.ToListAsync();
        }
    }
}
