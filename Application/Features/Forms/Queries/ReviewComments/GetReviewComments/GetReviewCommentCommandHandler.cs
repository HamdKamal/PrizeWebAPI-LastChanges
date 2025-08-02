using AutoMapper.Internal;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Forms.Queries.ReviewComments.GetReviewComments
{
    public class GetReviewCommentQueryHandler : IGetReviewCommentQueryHandler
    {
        private IReviewCommentRepository _reviewCommentsRepository;

        public GetReviewCommentQueryHandler(
            IReviewCommentRepository reviewCommentsRepository
            )
        {
            _reviewCommentsRepository = reviewCommentsRepository;
        }

        public async Task<List<ReviewComment>?> HandleGetReviewCommentForResetStatusAsync(int formSubmissionId) 
        {
            return await _reviewCommentsRepository.GetReviewCommentsForResetStatusAsync(formSubmissionId);            
        }
    }
}

