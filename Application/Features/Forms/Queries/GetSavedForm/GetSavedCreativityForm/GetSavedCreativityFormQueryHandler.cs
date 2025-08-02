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

namespace Application.Features.Forms.Queries.GetSavedForm.GetSavedCreativityForm
{
    public class GetSavedCreativityFormQueryHandler : IGetSavedCreativityFormQueryHandler
    {
        private IFormSubmissionRepository _formSubmissionRepository;
        private ISubmittedAnswerRepository _submittedAnswersRepository;
        private ISubmittedAttachmentRepository _submittedAttachmentsRepository;
        private IParticipantRepository _participantRepository;
        private IFormSectionRepository _formSectionRepository;
        private IQuestionRepository _questionRepository;

        public GetSavedCreativityFormQueryHandler(
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

        public async Task<GetSavedCreativityFormQueryResult> HandleAsync(GetSavedCreativityFormQueryModel getSavedCreativityFormQueryModel)
        {
            GetSavedCreativityFormQueryResult result = new GetSavedCreativityFormQueryResult();
            result.draftForm = new List<Dictionary<int, FormSubmission>>();
            result.initialFormValues = new List<Dictionary<int, object>>();

            var formSubmission = await _formSubmissionRepository.GetByFormSubmissionIdAsync(getSavedCreativityFormQueryModel.FormSubmissionId);
            var formSections = await _formSectionRepository.GetFormSectionsByCategoryIdAsync((int)FormCategoryEnum.Individual);

            foreach (var section in formSections) 
            {
                //set draft form
                var sectionSubmission = new FormSubmission() 
                {
                    Id = formSubmission.Id, 
                    UserId = formSubmission.UserId,
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

                sectionSubmission.Participants = section.Id.Equals(8) ? formSubmission.Participants : null;

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
                if (section.Id.Equals(8))
                {
                    var initialValueDict = new Dictionary<int, object>();
                    initialValueDict[section.Id] = new
                    {
                        participants = formSubmission.Participants.Select(p => new
                        {
                            name = p.Name,
                            jobTitle = p.JobTitle,
                            department = p.Department,
                            subDepartment = p.SubDepartment,
                            email = p.Email ?? String.Empty,
                            mobile = p.MobileNumber ?? String.Empty,
                        }).ToList(),
                    };
                    result.initialFormValues.Add(initialValueDict);
                }
                else 
                {
                    if (subSectionIds.Count() > 0)
                    {
                        foreach (var subsectionId in subSectionIds)
                        {
                            List<int> questionKeys = section.SubSections.Where(s => s.Id.Equals(subsectionId)).SelectMany(s=> s.Questions).Select(q => q.Id).ToList();

                            if (questionKeys.Count() <= 0)
                            {
                                var sectionInitialValueDict = new Dictionary<int, object>();

                                sectionInitialValueDict[subsectionId] = new
                                {
                                    sectionAttachments = formSubmission.SubmittedAttachments?.Where(a =>
                                                (
                                                    a.SubSectionId is not null
                                                    && subsectionId.Equals((int)a.SubSectionId)
                                                    && a.QuestionId is null
                                                )
                                    )
                                    .ToList(),
                                    sectionComment = formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                                (
                                                    a.SubSectionId is not null
                                                    && subsectionId.Equals((int)a.SubSectionId)
                                                    && a.QuestionId is null
                                                )
                                    )?.Answer ?? String.Empty
                                };

                                result.initialFormValues.Add(sectionInitialValueDict);
                            }
                            else 
                            {
                                foreach (var questionKey in questionKeys)
                                {
                                    var question = await _questionRepository.GetByIdAsync(questionKey);
                                    bool questionHasOptions = question.QuestionOptions.Count() > 0;
                                    bool optionsHaveComment = question.QuestionOptions.Where(qo => qo.Option.HasComment).ToList().Count() > 0;

                                    if (questionKey.Equals(subsectionId))
                                    {
                                        var initialValueDict = new Dictionary<int, object>();

                                        initialValueDict[questionKey] = new
                                        {
                                            sectionAttachments = formSubmission.SubmittedAttachments?.Where(a =>
                                                        (
                                                            a.SubSectionId is not null
                                                            && subsectionId.Equals((int)a.SubSectionId)
                                                            && a.QuestionId is null
                                                        )
                                            ).ToList(),
                                            sectionComment = formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                                        (
                                                            a.SubSectionId is not null
                                                            && subsectionId.Equals((int)a.SubSectionId)
                                                            && a.QuestionId is null
                                                        )
                                            )?.Answer ?? String.Empty,
                                            optionIds = questionHasOptions ? formSubmission.SubmittedAnswers?.Where(a =>
                                                        (
                                                            a.QuestionId is not null
                                                            && questionKey.Equals((int)a.QuestionId)
                                                        )
                                            ).Select(o => o.OptionId.ToString()).ToList() : null,
                                            answerText = !questionHasOptions ? formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                                        (
                                                            a.QuestionId is not null
                                                            && questionKey.Equals((int)a.QuestionId)
                                                        )
                                            )?.Answer : String.Empty,
                                            comment = questionHasOptions && optionsHaveComment ? formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                                        (
                                                            a.QuestionId is not null
                                                            && questionKey.Equals((int)a.QuestionId)
                                                        )
                                            )?.OptionComment : String.Empty,
                                        };

                                        result.initialFormValues.Add(initialValueDict);
                                    }
                                    else
                                    {
                                        var initialValueDict = new Dictionary<int, object>();

                                        initialValueDict[questionKey] = new
                                        {
                                            sectionAttachments = new List<object>(),
                                            sectionComment = String.Empty,
                                            optionIds = questionHasOptions ? formSubmission.SubmittedAnswers?.Where(a =>
                                                        (
                                                            a.QuestionId is not null
                                                            && questionKey.Equals((int)a.QuestionId)
                                                        )
                                            ).Select(o => o.OptionId.ToString()).ToList() : null,
                                            answerText = !questionHasOptions ? formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                                        (
                                                            a.QuestionId is not null
                                                            && questionKey.Equals((int)a.QuestionId)
                                                        )
                                            )?.Answer : String.Empty,
                                            comment = questionHasOptions && optionsHaveComment ? formSubmission.SubmittedAnswers?.FirstOrDefault(a =>
                                                        (
                                                            a.QuestionId is not null
                                                            && questionKey.Equals((int)a.QuestionId)
                                                            && a.OptionId is not null
                                                            && a.OptionComment is not null
                                                        )
                                            )?.OptionComment : String.Empty,
                                        };

                                        result.initialFormValues.Add(initialValueDict);
                                    }
                                }
                            }
                        }
                    }                        
                }
            }
            
            //initial values structure
            //for questions:
            //    [q.id] = {
            //        optionIds: [],
            //        answerText: "",
            //        comment: "",
            //        sectionAttachments: [],
            //        sectionComment: "",
            //      }            

            //for subsections
            //    [subSection.id] = { sectionAttachments: [], sectionComment: "" }
            
            //for section 8
            //    [8] = {
            //        participants:[{
            //            name: "",
            //            jobTitle: "",
            //            department: "",
            //            email: "",
            //            mobile: "",
            //         }]
            //    }
            
            return result;
        }
    }
}
