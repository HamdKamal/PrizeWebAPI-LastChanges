using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class ReviewCommentDTO
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
    }
}
