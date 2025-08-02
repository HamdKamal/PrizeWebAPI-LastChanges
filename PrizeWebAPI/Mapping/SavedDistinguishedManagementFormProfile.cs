using Application.Features.Forms.Queries.GetSavedForm.GetSavedDistinguishedManagementForm;
using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class SavedDistinguishedManagementFormProfile : Profile
    {
        public SavedDistinguishedManagementFormProfile()
        {

            // Add the main object mapping
            CreateMap<GetSavedDistinguishedManagementFormQueryResult, SavedDistinguishedManagementFormDTO>().ReverseMap();
        }
    }
}
