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
    
        public class SubscribtionControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
        {
            private readonly HttpClient _client;

            public SubscribtionControllerTests(CustomWebApplicationFactory<Startup> factory)
            {
                _client = factory.CreateClient();
            }

            [Fact]
            public async Task ShouldGetSubscriptions()
            {
                // The endpoint or route of the controller action.
                var httpResponse = await _client.GetAsync("/api/Subscription");

                // Must be successful.
                httpResponse.EnsureSuccessStatusCode();

                // Deserialize and examine results.
                var stringResponse = await httpResponse.Content.ReadAsStringAsync();
                var subscriptions = JsonConvert.DeserializeObject<IEnumerable<Subscription>>(stringResponse);
                Assert.Contains(subscriptions, s => s.Email== "test@test.com");
            }

        [Fact]
        public async Task ShouldUnsubscribe()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/Subscription/unsubscribe/QWERTY123456");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var customResponse = JsonConvert.DeserializeObject<CustomResponse>(stringResponse);
            Assert.Equal("success",customResponse.Message);
        }
    }
}
