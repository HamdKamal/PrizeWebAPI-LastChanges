using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubmittedAttachmentRepository
    {
        Task<List<SubmittedAttachment>> AddRangeAsync(List<SubmittedAttachment> submittedAttachments);
        Task<List<SubmittedAttachment>> UpdateRangeAsync(List<SubmittedAttachment> submittedAttachments);
        Task<List<SubmittedAttachment>?> GetByFormSubmissionIdAsync(int formSubmissionId);
        Task<List<SubmittedAttachment>?> GetByFormSubSectionIdAsync(int formSubSectionId);
        Task<List<SubmittedAttachment>?> GetByFormSubSectionId_AsNoTracking_Async(int formSubSectionId);
        Task<List<SubmittedAttachment>?> GetByQuestionIdAsync(int questionId);
        Task<List<SubmittedAttachment>?> GetByQuestionId_AsNoTracking_Async(int questionId);
        Task<SubmittedAttachment?> GetByIdAsync(int id);
        Task DeleteRangeAsync(List<SubmittedAttachment> submittedAttachments);
    }
}
