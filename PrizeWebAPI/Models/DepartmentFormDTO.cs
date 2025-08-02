using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class DepartmentFormDTO
    {
        public List<FormSectionDTO> formSections { get; set; }
        public List<FormSubSectionDTO> formSubSections { get; set; }
        public List<QuestionDTO> questions { get; set; }
    }


}

