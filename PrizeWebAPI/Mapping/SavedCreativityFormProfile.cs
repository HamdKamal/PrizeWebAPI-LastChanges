using Application.Features.Forms.Queries.GetSavedForm;
using Application.Features.Forms.Queries.GetSavedForm.GetSavedCreativityForm;
using AutoMapper;
using Core.Entities;
using PrizeWebAPI.Models;

namespace PrizeWebAPI.Mapping
{
    public class SavedCreativityFormProfile : Profile
    {
        public SavedCreativityFormProfile()
        {
            //// Add individual mappings for inner objects
            //CreateMap<FormSubmission, FormSubmissionDTO>().ReverseMap();
            //CreateMap<Participant, ParticipantDTO>().ReverseMap();
            //CreateMap<SubmittedAnswer, SubmittedAnswerDTO>().ReverseMap();
            //CreateMap<SubmittedAttachment, SubmittedAttachmentDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<GetSavedCreativityFormQueryResult, SavedCreativityFormDTO>().ReverseMap();
        }
    }
}
