using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.FormSubmissions.UpdateFormSubmissions
{
    public interface IUpdateFormSubmissionCommandHandler
    {
        Task<FormSubmission?> HandleFormRequestApprovalAsync(int submissionId);
        Task<FormSubmission?> HandleFormRequestRejectionAsync(int submissionId);
        Task<FormSubmission?> HandleReturnFormForModificationAsync(int submissionId);
    }
}
