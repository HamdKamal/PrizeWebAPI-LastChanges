using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.CreateNewForm
{
    public class CreateNewFormCommandHandler : ICreateNewFormCommandHandler
    {
        private IFormSubmissionRepository _formSubmissionRepository;
        private ISubmittedAnswerRepository _submittedAnswerRepository;
        private ISubmittedAttachmentRepository _submittedAttachmentRepository;
        private IParticipantRepository _participantRepository;

        public CreateNewFormCommandHandler(
            IFormSubmissionRepository formSubmissionRepository,
            ISubmittedAnswerRepository submittedAnswerRepository,
            ISubmittedAttachmentRepository submittedAttachmentRepository,
            IParticipantRepository particpantRepository
            ) 
        { 
            _formSubmissionRepository = formSubmissionRepository;
            _submittedAnswerRepository = submittedAnswerRepository;
            _submittedAttachmentRepository = submittedAttachmentRepository;
            _participantRepository = particpantRepository;
        }

        public async Task<CreateNewFormCommandResult> HandleAsync(CreateNewFormCommandModel queryModel)
        {
            try
            {
                CreateNewFormCommandResult result = new CreateNewFormCommandResult();

                queryModel.submission.SubmittedAttachments = null;
                queryModel.submission.SubmittedAnswers = null;
                queryModel.submission.Participants = null;

                result.submission = await _formSubmissionRepository.AddAsync(queryModel.submission);

                foreach (SubmittedAnswer answer in queryModel.answers)
                {
                    answer.SubmissionId = result.submission.Id;
                }
                foreach (SubmittedAttachment attachment in queryModel.attachments)
                {
                    attachment.SubmissionId = result.submission.Id;
                }

                result.answers = await _submittedAnswerRepository.AddRangeAsync(queryModel.answers);
                result.attachments = await _submittedAttachmentRepository.AddRangeAsync(queryModel.attachments);


                if (queryModel.participants != null && queryModel.participants.Count() > 0)
                {
                    foreach (Participant participant in queryModel.participants)
                    {
                        participant.SubmissionId = result.submission.Id;
                    }

                    result.particpants = await _participantRepository.AddRangeAsync(queryModel.participants);
                }

                return result;
            }
            catch (Exception ex)
            {
                // Log the error or rethrow with context
                throw new Exception("Error while creating new form submission", ex);
            }
        }
    }
}
