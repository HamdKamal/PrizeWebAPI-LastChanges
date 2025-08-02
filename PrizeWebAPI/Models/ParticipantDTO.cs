namespace PrizeWebAPI.Models
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public string? SubDepartment { get; set; }

        public int SubmissionId { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
    }

}
