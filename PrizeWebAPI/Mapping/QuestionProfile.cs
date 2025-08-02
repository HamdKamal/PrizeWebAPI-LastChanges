using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            //// Add individual mappings for inner objects
            //CreateMap<QuestionOption, QuestionOptionDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<Question, QuestionDTO>().ReverseMap();
        }
    }
}
