using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool HasComment { get; set; }
        public bool IsCommentRequired { get; set; }
        public string? CommentLabel { get; set; }
        public string? CommentPlaceholder { get; set; }
        public bool HasAttachment { get; set; }
        public bool IsAttachmentRequired { get; set; }
        public string? AttachmentLabel { get; set; }
        public string? AttachmentPlaceholder { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public virtual ICollection<QuestionOption>? QuestionOptions { get; set; } = new List<QuestionOption>();
        public virtual ICollection<SubmittedAnswer>? SubmittedAnswers { get; set; } = new List<SubmittedAnswer>();
        public virtual ICollection<SubmittedAttachment>? SubmittedAttachments { get; set; } = new List<SubmittedAttachment>();
    }
}
