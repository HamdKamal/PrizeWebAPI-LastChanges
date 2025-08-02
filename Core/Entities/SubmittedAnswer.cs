using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Core.Entities
{
    public class SubmittedAnswer
    {
        public int Id { get; set; }
        //[ForeignKey("FormSubmission")]
        public int SubmissionId { get; set; }
        public int? SubSectionId { get; set; }
        public int? QuestionId { get; set; }
        public int? OptionId { get; set; }
        public string? OptionComment{ get; set; }
        public string? Answer { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        [JsonIgnore]
        public virtual FormSubmission Submission { get; set; }
        [JsonIgnore]
        public virtual FormSubSection? SubSection { get; set; }
        [JsonIgnore]
        public virtual Question? Question { get; set; }
        [JsonIgnore]
        public virtual Option? Option { get; set; }
    }
}
