using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly PrizeDbContext _context;

        public StatusRepository(PrizeDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Status>> GetAllStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }
    }
}
