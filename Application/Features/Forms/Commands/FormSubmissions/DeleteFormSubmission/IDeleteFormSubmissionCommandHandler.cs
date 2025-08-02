using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.FormSubmissions.DeleteFormSubmission
{
    
    public interface IDeleteFormSubmissionCommandHandler
    {
        Task<bool> HandleAsync(int submissionId);
    }
}