using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class SubmittedAttachmentDTO
    {
        public int Id { get; set; }
        public IFormFile? File { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
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
    }
}
