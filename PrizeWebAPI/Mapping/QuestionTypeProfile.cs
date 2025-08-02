using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class QuestionTypeProfile : Profile
    {
        public QuestionTypeProfile()
        {
            CreateMap<QuestionType, QuestionTypeDTO>().ReverseMap();
        }
    }
}
