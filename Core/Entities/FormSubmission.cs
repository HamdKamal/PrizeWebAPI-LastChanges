using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class FormSubmission
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? ApplicantFullNameAr { get; set; }
        public string? DepartmentId { get; set; }
        public string? DepartmentNameAr { get; set; }
        public string? SubDepartment { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int? LastSubmittedSectionId { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? SubmittedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        [JsonIgnore]
        public virtual FormSection? LastSubmittedSection { get; set; }
        public virtual Category Category { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<SubmittedAttachment>? SubmittedAttachments { get; set; } = new List<SubmittedAttachment>();
        public virtual ICollection<SubmittedAnswer>? SubmittedAnswers { get; set; } = new List<SubmittedAnswer>();
        public virtual ICollection<Participant>? Participants { get; set; } = new List<Participant>();
        public virtual ICollection<ReviewComment>? ReviewComments { get; set; } = new List<ReviewComment>();

    }
}
