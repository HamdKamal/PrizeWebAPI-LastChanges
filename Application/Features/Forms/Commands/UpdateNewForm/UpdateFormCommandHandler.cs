using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.UpdateNewForm
{
    public class UpdateFormCommandHandler : IUpdateFormCommandHandler
    {
        private IFormSubmissionRepository _formSubmissionRepository;
        private ISubmittedAnswerRepository _submittedAnswerRepository;
        private ISubmittedAttachmentRepository _submittedAttachmentRepository;
        private IParticipantRepository _participantRepository;

        public UpdateFormCommandHandler(
            IFormSubmissionRepository formSubmissionRepository,
            ISubmittedAnswerRepository submittedAnswerRepository,
            ISubmittedAttachmentRepository submittedAttachmentRepository,
            IParticipantRepository participantRepository
            ) 
        { 
            _formSubmissionRepository = formSubmissionRepository;
            _submittedAnswerRepository = submittedAnswerRepository;
            _submittedAttachmentRepository = submittedAttachmentRepository;
            _participantRepository = participantRepository;
        }

        public async Task<UpdateFormCommandResult> HandleAsync(UpdateFormCommandModel commandModel)
        {
            UpdateFormCommandResult result = new UpdateFormCommandResult();

            commandModel.submission.SubmittedAttachments = null;
            commandModel.submission.SubmittedAnswers = null;
            commandModel.submission.Participants = null;

            result.submission = await _formSubmissionRepository.UpdateAsync(commandModel.submission);
            result.attachments = new List<SubmittedAttachment>();

            foreach (var subSectionId in commandModel.attachments.Where(a => a.SubSectionId!=null && a.QuestionId is null).Select(a=>a.SubSectionId).Distinct())
            {
                var existingAttachments = await _submittedAttachmentRepository.GetByFormSubSectionId_AsNoTracking_Async((int)subSectionId);

                if (existingAttachments != null && existingAttachments.Count() > 0)
                {
                    await _submittedAttachmentRepository.DeleteRangeAsync(existingAttachments);
                }

                var insertRecords = commandModel.attachments.Where(a => a.SubSectionId != null && a.SubSectionId.Equals(subSectionId) && a.QuestionId is null).ToList();
                
                foreach (var record in insertRecords) 
                {
                    record.Id = 0;
                }

                var insertedAttachments = await _submittedAttachmentRepository.AddRangeAsync(insertRecords);
                result.attachments.AddRange(insertedAttachments);
            }

            foreach (var item in commandModel.attachments.Where(a => a.QuestionId != null))
            {
                var existingAttachments = await _submittedAttachmentRepository.GetByQuestionId_AsNoTracking_Async((int)item.QuestionId);

                if (existingAttachments != null && existingAttachments.Count() > 0)
                {
                    await _submittedAttachmentRepository.DeleteRangeAsync(existingAttachments);
                }

                item.Id = 0;

                var insertedAttachments = await _submittedAttachmentRepository.AddRangeAsync(new List<SubmittedAttachment> { item });
                
                result.attachments.AddRange(insertedAttachments);
            }

            //Find removed/unselected multiple-choice answers and delete them
            var existingAnswers = await _submittedAnswerRepository.GetByFormSubmissionId_AsNoTracking_Async((int)commandModel.submission.Id);
            var existingMultipleChoiceAnswers = existingAnswers?.Where(a=> a.QuestionId is not null)
                                        .GroupBy(a => new { a.QuestionId, a.Question?.QuestionTypeId })                                        
                                        .Where(g => g.Count() >= 1 && g.Key.QuestionTypeId.Equals((int)QuestionTypeEnum.MultipleChoice))
                                        .SelectMany(g => g) // flatten to individual answer entries
                                        .ToList() ?? new List<SubmittedAnswer>();

            var isAnswerSubmitted = commandModel.answers.Where(submitted =>
                        submitted.QuestionId is not null &&
                        submitted.OptionId is not null
                    ).Count()>0;

            var removedAnswers = existingMultipleChoiceAnswers?
                .Where(existing =>
                    isAnswerSubmitted
                    &&
                    !commandModel.answers.Any(submitted =>
                        submitted.QuestionId == existing.QuestionId &&
                        submitted.OptionId == existing.OptionId
                    )
                )
                .ToList();

            if (removedAnswers != null && removedAnswers.Count() > 0)
            {
                await _submittedAnswerRepository.DeleteRangeAsync(removedAnswers);
            }

            var updatedAnswers = await _submittedAnswerRepository.UpdateRangeAsync(commandModel.answers.Where(ans => ans.Id > 0).ToList());
            var insertedAnswers = await _submittedAnswerRepository.AddRangeAsync(commandModel.answers.Where(ans => ans.Id == 0).ToList());

            result.answers = updatedAnswers.Concat(insertedAnswers).ToList();
            
            if (commandModel.particpants != null && commandModel.particpants.Count() > 0)
            {
                var existingParticipants = await _participantRepository.GetByFormSubmissionIdAsync(result.submission.Id);
                if (existingParticipants != null && existingParticipants.Count() > 0)
                {
                    await _participantRepository.DeleteRangeAsync(existingParticipants);

                }

                var insertedParticipants = await _participantRepository.AddRangeAsync(commandModel.particpants.Where(p => p.Id == 0).ToList());

                result.particpants = insertedParticipants;
            }

            return result;
        }
    }
}
