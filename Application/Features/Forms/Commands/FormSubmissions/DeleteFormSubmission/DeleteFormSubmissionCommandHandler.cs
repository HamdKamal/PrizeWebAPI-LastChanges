using Core.Interfaces;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.FormSubmissions.DeleteFormSubmission
{
    /// <summary>
    /// Concrete command handler responsible for deleting a form submission via the repository.
    /// </summary>
    public class DeleteFormSubmissionCommandHandler : IDeleteFormSubmissionCommandHandler
    {
        private readonly IFormSubmissionRepository _formSubmissionRepository;

        public DeleteFormSubmissionCommandHandler(IFormSubmissionRepository formSubmissionRepository)
        {
            _formSubmissionRepository = formSubmissionRepository;
        }

        public async Task<bool> HandleAsync(int submissionId)
        {
            return await _formSubmissionRepository.DeleteAsync(submissionId);
        }
    }
}