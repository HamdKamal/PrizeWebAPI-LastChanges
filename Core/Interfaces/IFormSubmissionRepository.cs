using Core.Entities;

namespace Core.Interfaces
{
    public interface IFormSubmissionRepository
    {
        Task<FormSubmission> AddAsync(FormSubmission formSubmission);
        Task<FormSubmission> UpdateAsync(FormSubmission formSubmission);
        Task<FormSubmission?> GetByFormSubmissionIdAsync(int formSubmissionId);
        Task<bool> ValidateIndividualSubmissionLimit(string UserId);
        Task<bool> ValidateDepartmentSubmissionLimit(string? DepartmentId);
        Task<List<FormSubmission>> GetUserSubmissionsList(string UserID);
        Task<List<FormSubmission>> GetDepartmentSubmissionsList(string? DepartmentId);
        Task<List<FormSubmission>> GetFormSubmissionsByUserId(string userId);
        Task<List<FormSubmission>> GetDepartmentFormsForAdminDashboard(string? statusId, int? submissionId, string? applicantName, string? departmentName);
        Task<List<FormSubmission>> GetIndividualFormsForAdminDashboard(string? statusId, int? submissionId, string? applicantName, string? departmentName);
        Task<FormSubmission?> ApproveAsync(int submissionId);
        Task<FormSubmission?> RejectAsync(int submissionId);
        Task<FormSubmission?> ReturnForModificationAsync(int submissionId);
        Task<FormSubmission?> MarkUnderReviewAsync(int submissionId);

        Task<bool> DeleteAsync(int submissionId);
        Task<List<FormSubmission>> GetPendingSubmissionsForReminderAsync();

    }
}
