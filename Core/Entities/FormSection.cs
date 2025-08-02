namespace Core.Entities
{
    public class FormSection
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
        public virtual Category Category { get; set; }
        public virtual ICollection<FormSubSection>? SubSections { get; set; } = new List<FormSubSection>();
        public virtual ICollection<FormSubmission>? Submissions { get; set; } = new List<FormSubmission>();

    }
}
