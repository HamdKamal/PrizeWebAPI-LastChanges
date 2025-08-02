using Core.Entities;
using Core.Enums;
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
    public class ReviewCommentRepository : IReviewCommentRepository
    {
        private readonly PrizeDbContext _context;

        public ReviewCommentRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewComment> AddAsync(ReviewComment reviewComment)
        {
            try 
            {
                _context.ReviewComments.Add(reviewComment);
                await _context.SaveChangesAsync();
                return reviewComment;
            }
            catch (Exception ex)
            {
                // You can log the exception here if you have a logger
                // e.g. _logger.LogError(ex, "Error adding FormSubmission");

                // Optionally, rethrow or return null, or handle as needed
                //throw new ApplicationException("An error occurred while saving the form submission.", ex);
                throw new Exception("An error occurred while saving the form submission." + ex.Message + (ex.InnerException?.Message??""), ex);
            }
        }

        public async Task<ReviewComment> UpdateAsync(ReviewComment reviewComment)
        {
            _context.ReviewComments.Update(reviewComment);
            await _context.SaveChangesAsync();
            return reviewComment;
        }    

        public async Task<List<ReviewComment>?> GetReviewCommentsForResetStatusAsync(int submissionId)
        {
            var formSubmission = await _context.FormSubmissions.FirstOrDefaultAsync(f=> f.Id.Equals(submissionId));

            if (formSubmission != null) 
            {
                return await _context.ReviewComments.Where(rc => rc.FormSubmissionId.Equals(submissionId)).ToListAsync();
            }
            else return null;
        }
    }
}
