using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TB.EmailSubscriber.Models;

namespace TB.EmailSubscriber.Persistence
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetTopics();
        Task<Topic> GetTopic(int id);
    }
}
