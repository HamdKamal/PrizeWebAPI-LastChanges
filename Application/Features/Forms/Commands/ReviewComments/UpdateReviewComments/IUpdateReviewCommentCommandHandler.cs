using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.ReviewComments.UpdateReviewComments
{
    public interface IUpdateReviewCommentCommandHandler
    {
        Task<ReviewComment?> HandleSaveReviewCommentAsync(ReviewComment comment);
    }
}
