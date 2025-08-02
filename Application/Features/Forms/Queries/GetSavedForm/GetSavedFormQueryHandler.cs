using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Queries.GetSavedForm
{
    public class GetSavedFormQueryHandler : IGetSavedFormQueryHandler
    {
        private IFormSubmissionRepository _formSubmissionRepository;
        private ISubmittedAnswerRepository _submittedAnswersRepository;
        private ISubmittedAttachmentRepository _submittedAttachmentsRepository;
        private IParticipantRepository _participantRepository;

        public GetSavedFormQueryHandler(
            IFormSubmissionRepository formSubmissionRepository,
            ISubmittedAnswerRepository submittedAnswersRepositor,
            ISubmittedAttachmentRepository submittedAttachmentsRepository, 
            IParticipantRepository participantRepository
            ) 
        { 
            _formSubmissionRepository = formSubmissionRepository;
            _submittedAnswersRepository = submittedAnswersRepositor;
            _submittedAttachmentsRepository = submittedAttachmentsRepository;
            _participantRepository = participantRepository; 
        }

        public async Task<GetSavedFormQueryResult> HandleAsync(GetSavedFormQueryModel getSavedFormQueryModel)
        {
            GetSavedFormQueryResult result = new GetSavedFormQueryResult();

            result.formSubmission = await _formSubmissionRepository.GetByFormSubmissionIdAsync(getSavedFormQueryModel.FormSubmissionId);
            result.submittedAnswers = await _submittedAnswersRepository.GetByFormSubmissionIdAsync(getSavedFormQueryModel.FormSubmissionId);
            result.submittedAttachments = await _submittedAttachmentsRepository.GetByFormSubmissionIdAsync(getSavedFormQueryModel.FormSubmissionId);
            result.particpants = await _participantRepository.GetByFormSubmissionIdAsync(getSavedFormQueryModel.FormSubmissionId);

            return result;
        }
    }
}
