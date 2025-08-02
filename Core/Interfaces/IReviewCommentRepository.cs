using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReviewCommentRepository
    {
        Task<ReviewComment> AddAsync(ReviewComment reviewComment);
        Task<ReviewComment> UpdateAsync(ReviewComment reviewComment);
        Task<List<ReviewComment>?> GetReviewCommentsForResetStatusAsync(int submissionId);
    }
}
