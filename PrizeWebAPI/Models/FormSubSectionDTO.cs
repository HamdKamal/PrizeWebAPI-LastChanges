namespace PrizeWebAPI.Models
{
    public class FormSubSectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormSectionId { get; set; }
        public bool HasAttachment { get; set; }
        public bool IsAttachmentRequired { get; set; }
        public string? AttachmentLabel { get; set; }
        public string? AttachmentPlaceholder { get; set; }
        public bool HasComment { get; set; }
        public bool IsCommentRequired { get; set; }
        public string? CommentLabel { get; set; }
        public string? CommentPlaceholder { get; set; }
        public int OrderIndex { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();

    }

}
