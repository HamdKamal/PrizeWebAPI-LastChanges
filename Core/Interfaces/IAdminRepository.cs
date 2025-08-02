using Core.Entities;

namespace Core.Interfaces
{
    public interface IAdminRepository
    {
        Task<bool> IsAdmin(string userId);
        Task<List<AdminUser>> GetAllAsync();
        Task<AdminUser> AddAsync(AdminUser adminUser);
        Task<bool> RemoveAsync(string userId);
    }
}