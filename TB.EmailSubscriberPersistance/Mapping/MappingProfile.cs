using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TB.EmailSubscriber.Models;

namespace TB.EmailSubscriber.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SubscriptionResource, Subscription>()
             .ForMember(s => s.Id, opt => opt.Ignore())
             .ForMember(s => s.Email, opt => opt.MapFrom(sr => sr.Email))
             .ForMember(s => s.Topics, opt => opt.Ignore())
             .AfterMap((sr, s) => {
                 // Add new groups
                 var addedTopics = sr.Topics.Where(id => !s.Topics.Any(t => t.TopicId == id)).Select(id => new SubscribtionTopic { TopicId = id }).ToList();
                 foreach (var t in addedTopics)
                     s.Topics.Add(t);
             });
        }
    }
}
