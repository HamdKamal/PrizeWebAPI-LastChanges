using Application.Features.Forms.Queries.GetNewForm.GetNewDepartmentForm;
using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class DepartmentFormProfile : Profile
    {
        public DepartmentFormProfile()
        {
            // Add individual mappings for inner objects
            //CreateMap<FormSection, FormSectionDTO>().ReverseMap();
            //CreateMap<FormSubSection, FormSubSectionDTO>().ReverseMap();
            //CreateMap<Question, QuestionDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<GetNewDepartmentFormQueryResult, DepartmentFormDTO>().ReverseMap();
        }
    }
}