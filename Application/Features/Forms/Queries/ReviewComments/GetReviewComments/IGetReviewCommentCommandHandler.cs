using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.ReviewComments.GetReviewComments
{
    public interface IGetReviewCommentQueryHandler
    {
        Task<List<ReviewComment>?> HandleGetReviewCommentForResetStatusAsync(int formSubmissionId);
    }
}
