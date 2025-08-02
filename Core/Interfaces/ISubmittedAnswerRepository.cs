using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubmittedAnswerRepository
    {
        Task<List<SubmittedAnswer>> AddRangeAsync(List<SubmittedAnswer> submittedAnswers);
        Task<List<SubmittedAnswer>> UpdateRangeAsync(List<SubmittedAnswer> submittedAnswers);
        Task<List<SubmittedAnswer>?> GetByFormSubmissionIdAsync(int formSubmissionId);
        Task<List<SubmittedAnswer>?> GetByFormSubmissionId_AsNoTracking_Async(int formSubmissionId);
        Task DeleteRangeAsync(List<SubmittedAnswer> submittedAnswers);
    }
}
