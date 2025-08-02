using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class ReviewComment
    {
        public int Id { get; set; }
        public string AdminUserId { get; set; }
        public int FormSubmissionId { get; set; }
        public int? FormSubSectionId { get; set; }
        public int? QuestionId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        [JsonIgnore]
        public virtual FormSubmission FormSubmission { get; set; }
        [JsonIgnore]
        public virtual Question? Question { get; set; }
        [JsonIgnore]
        public virtual FormSubSection? FormSubSection { get; set; }

    }
}
