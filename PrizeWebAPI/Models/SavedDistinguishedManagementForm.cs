using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class SavedDistinguishedManagementFormDTO
    {
        public List<Dictionary<int, FormSubmissionDTO>> draftForm { get; set; }
        public List<Dictionary<string, object>> initialFormValues { get; set; }
    }

}
