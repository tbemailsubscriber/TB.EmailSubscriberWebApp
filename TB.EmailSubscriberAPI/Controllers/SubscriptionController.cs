using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TB.EmailSubscriber.EmailDistributor;
using TB.EmailSubscriber.Models;
using TB.EmailSubscriber.Persistence;
using TB.EmailSubscriber.TokenGenerator;

namespace TB.EmailSubscriberAPI.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubscriptionController(ISubscriptionRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Subscription>> Get()
        {
            return await _repository.GetSubscriptions();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> Get(int id)
        {
            return await _repository.GetSubscription(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<CustomResponse> Post([FromBody] SubscriptionResource subscriptionResource)
        {
            try
            {
                if (!EmailValidator.IsValidEmail(subscriptionResource.Email))
                    return CustomResponse.CreateCustomResponse(400, "Invalid Email Address");
                if (!ModelState.IsValid)
                    return CustomResponse.CreateCustomResponse(400, "Invalid data");

                if (_repository.SubscriptionExist(subscriptionResource.Email))
                    return CustomResponse.CreateCustomResponse(409, "Email already exist");


                var subscription = _mapper.Map<SubscriptionResource, Subscription>(subscriptionResource);
                subscription.SubscribeDate = DateTime.Now;
                subscription.UniqueToken = Token.GetToken(subscription.Email);
                _repository.Subscribe(subscription);
                await _unitOfWork.CompleteAsync();

                subscription = _repository.GetSubscription(subscription.Id).Result;
                string[] topics = subscription.Topics.Select(t => t.Topic.Name).ToArray();

                new EmailSender().SendConfirmation(subscription.Email, subscription.UniqueToken, topics);

                return CustomResponse.CreateCustomResponseWithData(200, "Success", subscription);
            }
            catch (Exception ex)
            {
                return CustomResponse.CreateCustomResponse(500, "Error" + ex.Message);
            }
        }
       

        // DELETE api/values/5
        [HttpGet("unsubscribe/{unsubscribeToken}")]
        public async Task<CustomResponse> Delete(string unsubscribeToken)
        {
            try
            {
                string email = _repository.GetSubscription(unsubscribeToken).Result.Email;
                _repository.Unsubscribe(unsubscribeToken);
                await _unitOfWork.CompleteAsync();
                
                new EmailSender().SendUnsubscribeConfirmation(email);
                return CustomResponse.CreateCustomResponse(200, "Success");
            }
            catch (Exception ex)
            {
                return CustomResponse.CreateCustomResponse(500, "Error" + ex.Message);
            }
        }
    }
}
