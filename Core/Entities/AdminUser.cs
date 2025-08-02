using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class AdminUser
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}