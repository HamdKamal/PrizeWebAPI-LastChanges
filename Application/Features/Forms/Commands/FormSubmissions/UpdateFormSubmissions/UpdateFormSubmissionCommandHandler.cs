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

namespace Application.Features.Forms.Commands.FormSubmissions.UpdateFormSubmissions
{
    public class UpdateFormSubmissionCommandHandler : IUpdateFormSubmissionCommandHandler
    {
        private IFormSubmissionRepository _formSubmissionsRepository;

        public UpdateFormSubmissionCommandHandler(
            IFormSubmissionRepository formSubmissionsRepository
            )
        {
            _formSubmissionsRepository = formSubmissionsRepository;
        }

        public async Task<FormSubmission?> HandleFormRequestApprovalAsync(int submissionId)
        {
            FormSubmission? result = await _formSubmissionsRepository.ApproveAsync(submissionId);

            return result;
        }

        public async Task<FormSubmission?> HandleFormRequestRejectionAsync(int submissionId)
        {
            FormSubmission? result = await _formSubmissionsRepository.RejectAsync(submissionId);

            return result;
        }

        public async Task<FormSubmission?> HandleReturnFormForModificationAsync(int submissionId)
        {
            FormSubmission? result = await _formSubmissionsRepository.ReturnForModificationAsync(submissionId);

            return result;
        }

    }
}

