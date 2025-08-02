using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class IndividualFormDTO
    {
        public List<FormSectionDTO> formSections { get; set; }
        public List<FormSubSectionDTO> formSubSections { get; set; }
        public List<QuestionDTO> questions { get; set; }
        public List<ParticipantDTO>? participants{ get; set; }
    }

}
