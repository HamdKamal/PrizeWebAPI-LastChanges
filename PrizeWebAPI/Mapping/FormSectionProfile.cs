using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class FormSectionProfile : Profile
    {
        public FormSectionProfile()
        {
            //// Add individual mappings for inner objects
            //CreateMap<FormSubSection, FormSubSectionDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<FormSection, FormSectionDTO>().ReverseMap();
        }
    }
}
