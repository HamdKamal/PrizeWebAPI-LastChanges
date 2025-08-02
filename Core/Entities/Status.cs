using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormSubmission>? Submissions { get; set; } = new List<FormSubmission>();
    }


}
