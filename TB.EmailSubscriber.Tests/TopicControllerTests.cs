using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TB.EmailSubscriber.Models;
using TB.EmailSubscriberAPI;
using Xunit;

namespace TB.EmailSubscriber.Tests
{
    public class TopicControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public TopicControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ShouldGetTopics()
        {
            var httpResponse = await _client.GetAsync("/api/topic");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var topics = JsonConvert.DeserializeObject<IEnumerable<Topic>>(stringResponse);
            Assert.Contains(topics, t => t.Name == "Topic1");
        }

        [Fact]
        public async Task ShouldGetTopic()
        {
            var httpResponse = await _client.GetAsync("/api/topic/1");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var topic = JsonConvert.DeserializeObject<Topic>(stringResponse);
            Assert.Equal("Topic1", topic.Name);
        }
    }
}
