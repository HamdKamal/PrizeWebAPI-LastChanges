using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<Participant, ParticipantDTO>().ReverseMap();
        }
    }
}
