using AutoMapper;
using PrizeWebAPI.Models;
using Core.Entities;

namespace PrizeWebAPI.Mapping
{
    public class DashboardListProfile : Profile
    {
        public DashboardListProfile()
        {
            CreateMap<FormSubmission, DashboardListDTO>()
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
             .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name));

        }
    }
}
