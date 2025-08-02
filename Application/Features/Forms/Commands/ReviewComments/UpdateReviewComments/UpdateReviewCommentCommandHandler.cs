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

namespace Application.Features.Forms.Commands.ReviewComments.UpdateReviewComments
{
    public class UpdateReviewCommentCommandHandler : IUpdateReviewCommentCommandHandler
    {
        private IFormSubmissionRepository _formSubmissionsRepository;
        private IReviewCommentRepository _reviewCommentsRepository;

        public UpdateReviewCommentCommandHandler(
            IFormSubmissionRepository formSubmissionsRepository,
            IReviewCommentRepository reviewCommentsRepository
            )
        {
            _formSubmissionsRepository = formSubmissionsRepository;
            _reviewCommentsRepository = reviewCommentsRepository;
        }

        public async Task<ReviewComment?> HandleSaveReviewCommentAsync(ReviewComment comment) 
        {
            ReviewComment? result = null;

            if (comment.Id > 0)
                result = await _reviewCommentsRepository.UpdateAsync(comment);
            else
                result = await _reviewCommentsRepository.AddAsync(comment);
            
            if (result != null) 
            {
                var formSubmission = await _formSubmissionsRepository.MarkUnderReviewAsync(comment.FormSubmissionId);
            }
            return result;
        }
    }
}

