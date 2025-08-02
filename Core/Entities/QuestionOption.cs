using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class QuestionOption
    {
        public int Id { get; set; }
        //[ForeignKey("Question")]
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public virtual Question Question { get; set; }
        public virtual Option Option { get; set; }
    }
}
