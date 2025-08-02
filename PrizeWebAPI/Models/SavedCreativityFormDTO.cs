using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class SavedCreativityFormDTO
    {
        public List<Dictionary<int, FormSubmissionDTO>> draftForm { get; set; }
        public List<Dictionary<int, object>> initialFormValues { get; set; }
    }

}
