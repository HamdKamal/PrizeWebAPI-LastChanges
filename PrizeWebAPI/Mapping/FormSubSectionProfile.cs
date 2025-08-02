using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class FormSubSectionProfile : Profile
    {
        public FormSubSectionProfile()
        {
            //// Add individual mappings for inner objects
            //CreateMap<Question, QuestionDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<FormSubSection, FormSubSectionDTO>().ReverseMap();
        }
    }
}
