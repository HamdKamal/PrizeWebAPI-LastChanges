using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FormSubSectionRepository : IFormSubSectionRepository
    {
        private readonly PrizeDbContext _context;

        public FormSubSectionRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormSubSection>> GetBySectionIdAsync(int sectionId)
        {
            return await _context.FormSubSections.Where(fs => fs.FormSectionId.Equals(sectionId)).ToListAsync();
        }
    }
}
