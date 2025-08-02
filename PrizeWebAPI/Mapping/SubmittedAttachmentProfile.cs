using AutoMapper;
using PrizeWebAPI.Models;
using Core.Entities;

namespace PrizeWebAPI.Mapping
{
    public class SubmittedAttachmentProfile : Profile
    {
        public SubmittedAttachmentProfile()
        {
            CreateMap<SubmittedAttachment, SubmittedAttachmentDTO>()
                .ForMember(dest => dest.File, opt => opt.Ignore()) // Ignore during mapping to DTO
                .ReverseMap()
                .ForSourceMember(src => src.File, opt => opt.DoNotValidate());
        }
    }
}

