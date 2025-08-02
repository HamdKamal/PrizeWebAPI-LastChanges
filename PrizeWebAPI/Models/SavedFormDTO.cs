using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class SavedFormDTO
    {
        public FormSubmissionDTO formSubmission { get; set; }
        public List<SubmittedAnswerDTO> submittedAnswers { get; set; }
        public List<SubmittedAttachmentDTO> submittedAttachments { get; set; }
        public List<ParticipantDTO>? particpants { get; set; }
    }

}
