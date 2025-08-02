using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class SubmittedAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        //[ForeignKey("FormSubmission")]
        public int SubmissionId { get; set; }
        public int? SubSectionId { get; set; }
        public int? QuestionId { get; set; }
        public int? OptionId { get; set; }
        public int AttachmentTypeId { get; set; }
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
        [JsonIgnore]
        public virtual AttachmentType AttachmentType { get; set; }
    }
}
