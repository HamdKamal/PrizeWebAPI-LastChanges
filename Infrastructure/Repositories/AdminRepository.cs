using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AdminRepository(PrizeDbContext context) : IAdminRepository
    {
        private readonly PrizeDbContext _context = context;

        public async Task<AdminUser> AddAsync(AdminUser adminUser)
        {
            _context.Set<AdminUser>().Add(adminUser);
            await _context.SaveChangesAsync();
            return adminUser;
        }

        public async Task<List<AdminUser>> GetAllAsync()
        {
            return await _context.Set<AdminUser>().ToListAsync();
        }

        public async Task<bool> IsAdmin(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) return false;
            if (!userId.StartsWith("u", StringComparison.OrdinalIgnoreCase))
                userId = "u" + userId;
            return await _context.Set<AdminUser>().AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> RemoveAsync(string userId)
        {
            var admin = await _context.Set<AdminUser>().FirstOrDefaultAsync(a => a.UserId == userId);
            if (admin != null)
            {
                _context.Remove(admin);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}