using AutoMapper;
using PrizeWebAPI.Models;
using Core.Entities;

namespace PrizeWebAPI.Mapping
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<Option, OptionDTO>().ReverseMap();
        }
    }
}
