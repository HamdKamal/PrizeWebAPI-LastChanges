using Core.Entities;

namespace PrizeWebAPI.Models
{
    public class FormSectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int OrderIndex { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public List<FormSubSectionDTO> SubSections { get; set; }
    }

}
