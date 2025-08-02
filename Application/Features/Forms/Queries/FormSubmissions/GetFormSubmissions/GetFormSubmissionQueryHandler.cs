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

namespace Application.Features.Forms.Queries.FormSubmissions.GetFormSubmissions
{
    public class GetFormSubmissionQueryHandler : IGetFormSubmissionQueryHandler
    {
        private IFormSubmissionRepository _formSubmissionsRepository;

        public GetFormSubmissionQueryHandler(
            IFormSubmissionRepository formSubmissionsRepository
            )
        {
            _formSubmissionsRepository = formSubmissionsRepository;
        }

        public async Task<List<FormSubmission>> HandleGetDepartmentSubmissionsAsync(string departmentId)
        {
            List<FormSubmission> result = new List<FormSubmission>();

            result = await _formSubmissionsRepository.GetDepartmentSubmissionsList(departmentId);

            return result;
        }

        public async Task<List<FormSubmission>> HandleGetUserSubmissionsAsync(string userId)
        {
            List<FormSubmission> result = new List<FormSubmission>();

            result = await _formSubmissionsRepository.GetUserSubmissionsList(userId);

            return result;
        }

        public async Task<List<FormSubmission>> HandleGetFormSubmissionsByUserIdAsync(string userId)
        {
            List<FormSubmission> result = new List<FormSubmission>();

            result = await _formSubmissionsRepository.GetFormSubmissionsByUserId(userId);

            return result;
        }

        public async Task<bool> HandleValidateIndividualSubmissionLimit(string userId)
        {
            return await _formSubmissionsRepository.ValidateIndividualSubmissionLimit(userId);

        }

        public async Task<bool> HandleValidateDepartmentSubmissionLimit(string departmentId)
        {
            return await _formSubmissionsRepository.ValidateDepartmentSubmissionLimit(departmentId);

        }

        public async Task<List<FormSubmission>> HandleGetDepartmentFormsForAdminDashboardAsync(string? statusId, int? submissionId, string? applicantName, string? departmentName)
        {
            List<FormSubmission> result = new List<FormSubmission>();

            result = await _formSubmissionsRepository.GetDepartmentFormsForAdminDashboard(statusId, submissionId, applicantName, departmentName);

            return result;
        }

        public async Task<List<FormSubmission>> HandleGetIndividualFormsForAdminDashboardAsync(string? statusId, int? submissionId, string? applicantName, string? departmentName)
        {
            List<FormSubmission> result = new List<FormSubmission>();

            result = await _formSubmissionsRepository.GetIndividualFormsForAdminDashboard(statusId, submissionId, applicantName, departmentName);

            return result;
        }


    }
}

