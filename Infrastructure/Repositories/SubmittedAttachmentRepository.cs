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
    public class SubmittedAttachmentRepository : ISubmittedAttachmentRepository
    {
        private readonly PrizeDbContext _context;

        public SubmittedAttachmentRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubmittedAttachment>> AddRangeAsync(List<SubmittedAttachment> submittedAttachments)
        {
            try
            {
                _context.SubmittedAttachments.AddRange(submittedAttachments);
                await _context.SaveChangesAsync();
                return submittedAttachments;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<List<SubmittedAttachment>> UpdateRangeAsync(List<SubmittedAttachment> submittedAttachments)
        {
            _context.SubmittedAttachments.UpdateRange(submittedAttachments);
            await _context.SaveChangesAsync();
            return submittedAttachments;
        }

        public async Task<List<SubmittedAttachment>?> GetByFormSubmissionIdAsync(int formSubmissionId)
        {
            return await _context.SubmittedAttachments.Include(sa => sa.Question).Include(sa => sa.Option).Include(sa => sa.AttachmentType).Include(sa => sa.SubSection)
                .Where(sa => sa.SubmissionId.Equals(formSubmissionId))
                .ToListAsync();
        }
        public async Task<List<SubmittedAttachment>?> GetByFormSubSectionIdAsync(int subSectionId)
        {
            return await _context.SubmittedAttachments
                .Where(sa => sa.SubSectionId.Equals(subSectionId) && sa.QuestionId == null)
                .ToListAsync();
        }

        public async Task<List<SubmittedAttachment>?> GetByFormSubSectionId_AsNoTracking_Async(int subSectionId)
        {
            return await _context.SubmittedAttachments.AsNoTracking()
                .Where(sa => sa.SubSectionId.Equals(subSectionId) && sa.QuestionId == null)
                .ToListAsync();
        }

        public async Task<List<SubmittedAttachment>?> GetByQuestionIdAsync(int questionId)
        {
            return await _context.SubmittedAttachments
                .Where(sa => sa.QuestionId.Equals(questionId))
                .ToListAsync();
        }
        public async Task<List<SubmittedAttachment>?> GetByQuestionId_AsNoTracking_Async(int questionId)
        {
            return await _context.SubmittedAttachments.AsNoTracking()
                .Where(sa => sa.QuestionId.Equals(questionId))
                .ToListAsync();
        }
        public async Task<SubmittedAttachment?> GetByIdAsync(int id)
        {
            return await _context.SubmittedAttachments
                .FirstOrDefaultAsync(sa => sa.Id.Equals(id));
        }
        public async Task DeleteRangeAsync(List<SubmittedAttachment> submittedAttachments)
        {
            _context.SubmittedAttachments.RemoveRange(submittedAttachments);
            await _context.SaveChangesAsync();
        }
    }
}
