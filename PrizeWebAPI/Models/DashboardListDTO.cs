using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class DashboardListDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? DepartmentId { get; set; }
        public string? SubDepartment { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public string? CategoryName { get; set; }
        public string? StatusName { get; set; }
        public int? LastSubmittedSectionId { get; set; }
        public bool IsSubmitted { get; set; } = false;
        public DateTime? SubmittedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
