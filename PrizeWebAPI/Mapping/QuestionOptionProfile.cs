using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class QuestionOptionProfile : Profile
    {
        public QuestionOptionProfile()
        {
            CreateMap<QuestionOption, QuestionOptionDTO>().ReverseMap();
        }
    }
}
