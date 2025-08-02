using Application.Features.Forms.Queries.GetNewForm.GetNewIndividualForm;
using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class IndividualFormProfile : Profile
    {
        public IndividualFormProfile()
        {
            //// Add individual mappings for inner objects
            //CreateMap<FormSubSection, FormSubSectionDTO>().ReverseMap();
            //CreateMap<Question, QuestionDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<GetNewIndividualFormQueryResult, IndividualFormDTO>().ReverseMap();
        }
    }
}
