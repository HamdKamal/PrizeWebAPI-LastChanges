using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusDTO>().ReverseMap();
        }
    }
}
