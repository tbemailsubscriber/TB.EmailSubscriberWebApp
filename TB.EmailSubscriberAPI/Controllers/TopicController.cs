using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TB.EmailSubscriber.Models;
using TB.EmailSubscriber.Persistence;

namespace TB.EmailSubscriberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _repository;

        public TopicController(ITopicRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Topic
        [HttpGet]
        public async Task<IEnumerable<Topic>> Get()
        {
            return await _repository.GetTopics();
        }

        // GET: api/Topic/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Topic> Get(int id)
        {
            return await _repository.GetTopic(id);
        }
        
    }
}
