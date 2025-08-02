using AutoMapper;
using PrizeWebAPI.Models;
using Core.Entities;

namespace PrizeWebAPI.Mapping
{
    public class SubmittedAnswerProfile : Profile
    {
        public SubmittedAnswerProfile()
        {
            CreateMap<SubmittedAnswer, SubmittedAnswerDTO>().ReverseMap();
        }
    }
}
