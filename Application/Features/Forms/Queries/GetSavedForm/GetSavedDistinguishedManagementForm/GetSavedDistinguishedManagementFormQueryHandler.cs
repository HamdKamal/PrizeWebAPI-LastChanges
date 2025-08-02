using AutoMapper.Internal;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Forms.Queries.GetSavedForm.GetSavedDistinguishedManagementForm
{
    public class GetSavedDistinguishedManagementFormQueryHandler : IGetSavedDistinguishedManagementFormQueryHandler
    {
        private IFormSubmissionRepository _formSubmissionRepository;
        private ISubmittedAnswerRepository _submittedAnswersRepository;
        private ISubmittedAttachmentRepository _submittedAttachmentsRepository;
        private IParticipantRepository _participantRepository;
        private IFormSectionRepository _formSectionRepository;
        private IQuestionRepository _questionRepository;

        public GetSavedDistinguishedManagementFormQueryHandler(
            IFormSubmissionRepository formSubmissionRepository,
            ISubmittedAnswerRepository submittedAnswersRepositor,
            ISubmittedAttachmentRepository submittedAttachmentsRepository, 
            IParticipantRepository participantRepository,
            IFormSectionRepository formSectionRepository,
            IQuestionRepository questionRepository
            ) 
        { 
            _formSubmissionRepository = formSubmissionRepository;
            _submittedAnswersRepository = submittedAnswersRepositor;
            _submittedAttachmentsRepository = submittedAttachmentsRepository;
            _participantRepository = participantRepository; 
            _formSectionRepository = formSectionRepository;
            _questionRepository = questionRepository;
        }

        public async Task<GetSavedDistinguishedManagementFormQueryResult> HandleAsync(int submissionId)
        {
            GetSavedDistinguishedManagementFormQueryResult result = new GetSavedDistinguishedManagementFormQueryResult();
            result.draftForm = new List<Dictionary<int, FormSubmission>>();
            result.initialFormValues = new List<Dictionary<string, object>>();

            var formSubmission = await _formSubmissionRepository.GetByFormSubmissionIdAsync(submissionId);
            var formSections = await _formSectionRepository.GetFormSectionsByCategoryIdAsync((int)FormCategoryEnum.Department);

            foreach (var section in formSections) 
            {
                //set draft form
                var sectionSubmission = new FormSubmission() 
                {
                    Id = formSubmission.Id, 
                    UserId = formSubmission.UserId,
                    SubDepartment = formSubmission.SubDepartment,
                    DepartmentId = formSubmission.DepartmentId,
                    CategoryId = formSubmission.CategoryId,
                    StatusId = formSubmission.StatusId,
                    LastSubmittedSectionId = formSubmission.LastSubmittedSectionId,
                    IsSubmitted = formSubmission.IsSubmitted,
                    SubmittedAt = formSubmission.SubmittedAt,
                    CreatedAt = formSubmission.CreatedAt,
                    LastModifiedAt = formSubmission.LastModifiedAt,
                    CreatedBy = formSubmission.CreatedBy,
                    LastModifiedBy = formSubmission.LastModifiedBy,
                };
                List<int> subSectionIds = section.SubSections.Select(s => s.Id).ToList();
                List<int> questionIds= section.SubSections.SelectMany(s => s.Questions).Select(q=> q.Id).ToList();
                                
                if (subSectionIds.Count() > 0)
                {
                    sectionSubmission.SubmittedAnswers = formSubmission.SubmittedAnswers?.Where(a =>
                        (
                            a.SubSectionId is not null
                            && subSectionIds.Contains((int)a.SubSectionId) 
                            && a.QuestionId is null
                        ) || (
                            a.QuestionId is not null
                            && questionIds.Count() > 0 
                            && questionIds.Contains((int)a.QuestionId)
                        )
                    ).ToList();

                    sectionSubmission.SubmittedAttachments = formSubmission.SubmittedAttachments?.Where(a =>
                        (
                            a.SubSectionId is not null
                            && subSectionIds.Contains((int)a.SubSectionId)
                            && a.QuestionId is null
                        ) || (
                            a.QuestionId is not null
                            && questionIds.Count() > 0
                            && questionIds.Contains((int)a.QuestionId)
                        )
                    ).ToList();
                }
                else 
                {
                    sectionSubmission.SubmittedAnswers = new List<SubmittedAnswer>();
                    sectionSubmission.SubmittedAttachments = new List<SubmittedAttachment>();
                }

                result.draftForm.Add(new Dictionary<int, Core.Entities.FormSubmission>{ [section.Id] = sectionSubmission });
                //end - sent draft form

                //set initial values
                result.initialFormValues.Add(new Dictionary<string, object> { ["subDepartment"] = formSubmission.SubDepartment ?? String.Empty });

                if (subSectionIds.Count() > 0)
                {
                    foreach (var subsectionId in subSectionIds)
                    {
                        List<int> questionKeys = section.SubSections.Where(s => s.Id.Equals(subsectionId)).SelectMany(s=> s.Questions).Select(q => q.Id).ToList();

                        foreach (var questionKey in questionKeys)
                        {
                            var question = await _questionRepository.GetByIdAsync(questionKey);
                            bool questionHasOptions = question.QuestionOptions.Count() > 0;
                            var optionWithComment = question.QuestionOptions.FirstOrDefault(qo => qo.Option.HasComment).Option;
                            var optionWithAttachment = question.QuestionOptions.FirstOrDefault(qo => qo.Option.HasAttachment).Option;

                            var initialValueDict = new Dictionary<string, object>();

                            initialValueDict[questionKey.ToString()] = new
                            {
                                sectionAttachments = formSubmission.SubmittedAttachments?.FirstOrDefault(a =>
                                            (
                                                a.SubSectionId is not null
                                                && questionKey.Equals((int)a.SubSectionId)
                                                && a.QuestionId is null
                                                && a.AttachmentTypeId.Equals((int)AttachmentTypeEnum.SubSectionAttachment)
                                            )
                                ) ?? null,
                                sectionComment = formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                            (
                                                a.SubSectionId is not null
                                                && questionKey.Equals((int)a.SubSectionId)
                                                && a.QuestionId is null
                                            )
                                )?.Answer?.ToString() ?? String.Empty,
                                optionId = questionHasOptions ? formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                            (
                                                a.QuestionId is not null
                                                && a.OptionId is not null
                                                && questionKey.Equals((int)a.QuestionId)
                                            )
                                )?.OptionId?.ToString() ?? String.Empty : String.Empty,
                                attachments = questionHasOptions && optionWithAttachment != null ? formSubmission.SubmittedAttachments?.FirstOrDefault(a =>
                                            (
                                                a.QuestionId is not null
                                                && a.OptionId is not null
                                                && a.OptionId.Equals(optionWithAttachment.Id)
                                                && questionKey.Equals((int)a.QuestionId)
                                                && a.AttachmentTypeId.Equals((int)AttachmentTypeEnum.QuestionAttachment)
                                            )
                                ) : null,
                                comment = questionHasOptions && optionWithComment!=null ? formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                            (
                                                a.QuestionId is not null
                                                && a.OptionId is not null
                                                && a.OptionId.Equals(optionWithComment.Id)
                                                && questionKey.Equals((int)a.QuestionId)
                                            )
                                )?.OptionComment?.ToString() ?? String.Empty : String.Empty,
                            };

                            result.initialFormValues.Add(initialValueDict);
                            
                        }
                            
                    }
                }                        
                
            }

            //initial values structure 
            //{
            //    subDepartment: "",            
            //    [q1.id]: {
            //        optionId: "",
            //        attachments: null,
            //        comment: "",
            //        sectionAttachments: null,
            //        sectionComment: "",
            //    },
            //    [section1.id]: {
            //        optionId: "",
            //        attachments: null,
            //        comment: "",
            //        sectionAttachments: null,
            //        sectionComment: "",
            //    },
            //}

            return result;
        }
    }
}
