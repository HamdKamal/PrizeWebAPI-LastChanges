using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.FormSubmissions.GetFormSubmissions
{
    public interface IGetFormSubmissionQueryHandler
    {
        Task<List<FormSubmission>> HandleGetDepartmentSubmissionsAsync(string departmentId);
        Task<List<FormSubmission>> HandleGetUserSubmissionsAsync(string userId);
        Task<List<FormSubmission>> HandleGetFormSubmissionsByUserIdAsync(string userId);
        Task<bool> HandleValidateIndividualSubmissionLimit(string userId);
        Task<bool> HandleValidateDepartmentSubmissionLimit(string departmentId);
        Task<List<FormSubmission>> HandleGetDepartmentFormsForAdminDashboardAsync(string? statusId, int? submissionId, string? applicantName, string? departmentName);
        Task<List<FormSubmission>> HandleGetIndividualFormsForAdminDashboardAsync(string? statusId, int? submissionId, string? applicantName, string? departmentName);

    }
}
