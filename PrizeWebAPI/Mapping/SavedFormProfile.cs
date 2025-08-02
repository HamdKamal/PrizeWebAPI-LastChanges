using Application.Features.Forms.Queries.GetSavedForm;
using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class SavedFormProfile : Profile
    {
        public SavedFormProfile()
        {  
            //// Add individual mappings for inner objects
            //CreateMap<SubmittedAnswer, SubmittedAnswerDTO>().ReverseMap();
            //CreateMap<SubmittedAttachment, SubmittedAttachmentDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<GetSavedFormQueryResult, SavedFormDTO>().ReverseMap();
        }
    }

}
