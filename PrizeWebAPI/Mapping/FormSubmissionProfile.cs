using AutoMapper;
using PrizeWebAPI.Models;
using Core.Entities;

namespace PrizeWebAPI.Mapping
{
    public class FormSubmissionProfile : Profile
    {
        public FormSubmissionProfile()
        {
            //// Add individual mappings for inner objects
            //CreateMap<Participant, ParticipantDTO>().ReverseMap();
            //CreateMap<SubmittedAnswer, SubmittedAnswerDTO>().ReverseMap();
            //CreateMap<SubmittedAttachment, SubmittedAttachmentDTO>().ReverseMap();

            // Add the main object mapping
            CreateMap<FormSubmission, FormSubmissionDTO>().ReverseMap();
        }
    }
}
