namespace PrizeWebAPI.Models
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? QuestionPlaceholder { get; set; }
        public string? AnswerPlaceholder { get; set; }
        public int QuestionTypeId { get; set; }
        public bool IsRequired { get; set; }
        public int FormSubSectionId { get; set; }
        public int OrderIndex { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public QuestionTypeDTO QuestionType { get; set; }
        public List<QuestionOptionDTO> QuestionOptions { get; set; } = new List<QuestionOptionDTO>();
       
    }

}
