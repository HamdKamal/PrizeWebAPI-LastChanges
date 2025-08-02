using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FormSubmissionRepository : IFormSubmissionRepository
    {
        private readonly PrizeDbContext _context;

        public FormSubmissionRepository(PrizeDbContext context)
        {
            _context = context;
        }

        public async Task<FormSubmission> AddAsync(FormSubmission formSubmission)
        {
            try
            {
                _context.FormSubmissions.Add(formSubmission);
                await _context.SaveChangesAsync();
                return formSubmission;
            }
            catch (Exception ex)
            {
                // You can log the exception here if you have a logger
                // e.g. _logger.LogError(ex, "Error adding FormSubmission");

                // Optionally, rethrow or return null, or handle as needed
                //throw new ApplicationException("An error occurred while saving the form submission.", ex);
                throw new Exception("An error occurred while saving the form submission." + ex.Message + (ex.InnerException?.Message ?? ""), ex);
            }
        }

        public async Task<FormSubmission> UpdateAsync(FormSubmission formSubmission)
        {
            _context.FormSubmissions.Update(formSubmission);
            await _context.SaveChangesAsync();
            return formSubmission;
        }

        public async Task<FormSubmission?> GetByFormSubmissionIdAsync(int formSubmissionId)
        {
            return await _context.FormSubmissions.Include(f => f.SubmittedAnswers).ThenInclude(sa => sa.Question)
                    .Include(f => f.SubmittedAnswers).ThenInclude(sa => sa.Option)
                    .Include(f => f.SubmittedAnswers).ThenInclude(sa => sa.SubSection)
                    .Include(f => f.SubmittedAttachments).ThenInclude(sa => sa.Question)
                    .Include(f => f.SubmittedAttachments).ThenInclude(sa => sa.Option)
                    .Include(f => f.SubmittedAttachments).ThenInclude(sa => sa.AttachmentType)
                    .Include(f => f.SubmittedAttachments).ThenInclude(sa => sa.SubSection)
                    .Include(f => f.Participants)
                .Where(f => f.Id.Equals(formSubmissionId))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ValidateIndividualSubmissionLimit(string UserId)
        {
            var userSubmissions = await _context.FormSubmissions.
                            Where(a => a.UserId.Equals(UserId)
                                        && a.CategoryId.Equals((int)FormCategoryEnum.Individual)
                                        && a.IsSubmitted == true
                            ).ToListAsync();

            return userSubmissions.Count >= 3;
        }

        public async Task<bool> ValidateDepartmentSubmissionLimit(string? DepartmentId)
        {
            var departmentSubmissions = await _context.FormSubmissions.
                            Where(a => a.DepartmentId.Equals(DepartmentId)
                                    && a.CategoryId.Equals((int)FormCategoryEnum.Department)
                                    && !string.IsNullOrEmpty(a.DepartmentId)
                                    && !string.IsNullOrWhiteSpace(a.DepartmentId)
                                    && a.IsSubmitted == true
                            ).ToListAsync();

            return departmentSubmissions.Count >= 1;
        }

        public async Task<List<FormSubmission>> GetUserSubmissionsList(string UserID)
        {
            var userSubmissions = await _context.FormSubmissions.
                                        Where(a => a.UserId.Equals(UserID)
                                        && a.CategoryId.Equals((int)FormCategoryEnum.Individual)
                                        && a.IsSubmitted == true
                                        ).ToListAsync();
            return userSubmissions == null ? throw new Exception("No data was found.") : userSubmissions ?? [];
        }
        public async Task<List<FormSubmission>> GetDepartmentSubmissionsList(string? DepartmentId)
        {
            var departmentSubmissions = await _context.FormSubmissions.
                            Where(a => a.DepartmentId.Equals(DepartmentId)
                                    && a.CategoryId.Equals((int)FormCategoryEnum.Department)
                                    && !string.IsNullOrEmpty(a.DepartmentId)
                                    && !string.IsNullOrWhiteSpace(a.DepartmentId)
                                    && a.IsSubmitted == true
                            ).ToListAsync();

            return departmentSubmissions == null ? throw new Exception("No data was found.") : departmentSubmissions ?? [];
        }
        public async Task<List<FormSubmission>> GetFormSubmissionsByUserId(string userId)
        {
            return await _context.FormSubmissions
                .Include(f => f.Status)
                .Include(f => f.Category)
                .Where(a => a.UserId.Equals(userId) && a.IsDeleted != true)
                .ToListAsync() ?? [];
        }

        public async Task<List<FormSubmission>> GetDepartmentFormsForAdminDashboard(string? statusId, int? submissionId, string? applicantName, string? departmentName)
        {
            return await _context.FormSubmissions
                .Include(f => f.Status)
                .Include(f => f.Category)
                .Where(a =>
                    (a.StatusId.Equals(Convert.ToInt32(statusId)) || string.IsNullOrEmpty(statusId))
                    && (a.Id.Equals(Convert.ToInt32(submissionId)) || submissionId == null)
                    && a.CategoryId.Equals((int)FormCategoryEnum.Department)
                    && (a.DepartmentNameAr.Contains(departmentName) || string.IsNullOrEmpty(departmentName))
                    && (a.ApplicantFullNameAr.Contains(applicantName) || string.IsNullOrEmpty(applicantName))
                    && a.IsDeleted != true
                )
                .Select(f => new FormSubmission
                {
                    Id = f.Id,
                    UserId = f.UserId,
                    ApplicantFullNameAr = f.ApplicantFullNameAr,
                    DepartmentId = f.DepartmentId,
                    DepartmentNameAr = f.DepartmentNameAr,
                    StatusId = f.StatusId,
                    Status = f.Status,
                    CategoryId = f.CategoryId,
                    Category = f.Category,
                })
                .ToListAsync() ?? [];
        }

        public async Task<List<FormSubmission>> GetIndividualFormsForAdminDashboard(string? statusId, int? submissionId, string? applicantName, string? departmentName)
        {
            return await _context.FormSubmissions
                .Include(f => f.Status)
                .Include(f => f.Category)
                .Where(a =>
                    (a.StatusId.Equals(Convert.ToInt32(statusId)) || string.IsNullOrEmpty(statusId))
                    && (a.Id.Equals(Convert.ToInt32(submissionId)) || submissionId == null)
                    && a.CategoryId.Equals((int)FormCategoryEnum.Individual)
                    && (a.DepartmentNameAr.Contains(departmentName) || string.IsNullOrEmpty(departmentName))
                    && (a.ApplicantFullNameAr.Contains(applicantName) || string.IsNullOrEmpty(applicantName))
                    && a.IsDeleted != true
                )
                .Select(f => new FormSubmission
                {
                    Id = f.Id,
                    UserId = f.UserId,
                    ApplicantFullNameAr = f.ApplicantFullNameAr,
                    DepartmentId = f.DepartmentId,
                    DepartmentNameAr = f.DepartmentNameAr,
                    StatusId = f.StatusId,
                    Status = f.Status,
                    CategoryId = f.CategoryId,
                    Category = f.Category,
                })
                .ToListAsync() ?? [];
        }

        public async Task<FormSubmission?> ApproveAsync(int submissionId)
        {
            FormSubmission? formSubmission = _context.FormSubmissions.FirstOrDefault(f => f.IsSubmitted && f.Id.Equals(submissionId));
            if (formSubmission != null)
            {
                formSubmission.StatusId = (int)FormStatusEnum.Accepted;
                _context.FormSubmissions.Update(formSubmission);
                await _context.SaveChangesAsync();
                return formSubmission;
            }
            else return null;
        }

        public async Task<FormSubmission?> RejectAsync(int submissionId)
        {
            FormSubmission? formSubmission = _context.FormSubmissions.FirstOrDefault(f => f.IsSubmitted && f.Id.Equals(submissionId));
            if (formSubmission != null)
            {
                formSubmission.StatusId = (int)FormStatusEnum.Denied;
                _context.FormSubmissions.Update(formSubmission);
                await _context.SaveChangesAsync();
                return formSubmission;
            }
            else return null;
        }

        public async Task<FormSubmission?> ReturnForModificationAsync(int submissionId)
        {
            FormSubmission? formSubmission = _context.FormSubmissions.FirstOrDefault(f => f.IsSubmitted && f.Id.Equals(submissionId));
            if (formSubmission != null)
            {
                formSubmission.StatusId = (int)FormStatusEnum.Reset;
                _context.FormSubmissions.Update(formSubmission);
                await _context.SaveChangesAsync();
                return formSubmission;
            }
            else return null;
        }

        public async Task<FormSubmission?> MarkUnderReviewAsync(int submissionId)
        {
            FormSubmission? formSubmission = _context.FormSubmissions.FirstOrDefault(f => f.IsSubmitted && f.Id.Equals(submissionId));
            if (formSubmission != null)
            {
                formSubmission.StatusId = (int)FormStatusEnum.UnderReview;
                _context.FormSubmissions.Update(formSubmission);
                await _context.SaveChangesAsync();
                return formSubmission;
            }
            else return null;
        }

        public async Task<bool> DeleteAsync(int submissionId)
        {
            var submission = await _context.FormSubmissions.FindAsync(submissionId);
            if (submission != null && !submission.IsSubmitted)
            {
                submission.IsDeleted = true;
                submission.StatusId = (int)FormStatusEnum.DeletedByUser;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<FormSubmission>> GetPendingSubmissionsForReminderAsync()
        {
            return await _context.FormSubmissions
                .Where(f => !f.IsSubmitted && !f.IsDeleted)
                .ToListAsync();
        }

    }
}
