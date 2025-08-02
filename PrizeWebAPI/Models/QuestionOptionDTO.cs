namespace PrizeWebAPI.Models
{
    public class QuestionOptionDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

        public OptionDTO? Option { get; set; }
    }

}
