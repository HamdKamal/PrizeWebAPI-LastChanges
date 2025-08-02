using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? QuestionPlaceholder { get; set; }
        public string? AnswerPlaceholder { get; set; }
        public int QuestionTypeId { get; set; }
        public bool IsRequired { get; set; }
        //[ForeignKey("FormSubSection")]
        public int FormSubSectionId { get; set; }
        public int OrderIndex { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual FormSubSection FormSubSection { get; set; }
        public virtual ICollection<QuestionOption>? QuestionOptions { get; set; } = new List<QuestionOption>();
        public virtual ICollection<SubmittedAnswer>? SubmittedAnswers { get; set; } = new List<SubmittedAnswer>();
        public virtual ICollection<SubmittedAttachment>? SubmittedAttachments { get; set; } = new List<SubmittedAttachment>();
        public virtual ICollection<ReviewComment>? ReviewComments { get; set; } = new List<ReviewComment>();
    }
}
