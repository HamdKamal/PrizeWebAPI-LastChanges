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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly PrizeDbContext _context;

        public QuestionRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetBySubSectionIdAsync(int subSectionId)
        {
            return await _context.Questions
                .Include(q => q.QuestionOptions).ThenInclude(qa => qa.Option)
                .Include(q => q.QuestionType)//.ThenInclude(qo=> qo.Question).ThenInclude(qt => qt.QuestionType)
                .Where(q => q.FormSubSectionId.Equals(subSectionId))
                .ToListAsync();
        }
        public async Task<Question> GetByIdAsync(int Id)
        {
            return await _context.Questions
                .Include(q => q.QuestionOptions).ThenInclude(qa => qa.Option)
                .Include(q => q.QuestionType)
                .FirstOrDefaultAsync(q => q.Id.Equals(Id));
        }
    }
}
