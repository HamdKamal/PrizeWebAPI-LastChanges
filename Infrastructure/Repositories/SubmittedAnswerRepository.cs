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
    public class SubmittedAnswerRepository : ISubmittedAnswerRepository
    {
        private readonly PrizeDbContext _context;

        public SubmittedAnswerRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubmittedAnswer>> AddRangeAsync(List<SubmittedAnswer> submittedAnswers)
        {
            _context.SubmittedAnswers.AddRange(submittedAnswers);
            await _context.SaveChangesAsync();
            return submittedAnswers;
        }

        public async Task<List<SubmittedAnswer>> UpdateRangeAsync(List<SubmittedAnswer> submittedAnswers)
        {
            try 
            {
                _context.SubmittedAnswers.UpdateRange(submittedAnswers);
                await _context.SaveChangesAsync();
                return submittedAnswers;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public async Task DeleteRangeAsync(List<SubmittedAnswer> submittedAnswers)
        {
            _context.SubmittedAnswers.RemoveRange(submittedAnswers);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SubmittedAnswer>?> GetByFormSubmissionId_AsNoTracking_Async(int formSubmissionId)
        {
            return await _context.SubmittedAnswers.AsNoTrackingWithIdentityResolution()
                .Include(sa => sa.Question)
                .Where(sa => sa.SubmissionId.Equals(formSubmissionId))
                .ToListAsync();
        }

        public async Task<List<SubmittedAnswer>?> GetByFormSubmissionIdAsync(int formSubmissionId)
        {
            return await _context.SubmittedAnswers.Include(sa => sa.Question).Include(sa => sa.Option)
                .Where(sa => sa.SubmissionId.Equals(formSubmissionId))
                .ToListAsync();
        }
    }
}
