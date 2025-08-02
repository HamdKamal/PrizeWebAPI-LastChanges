using Application.Abstractions.Common;
using Application.Features.Forms.Commands.CreateNewForm;
using Application.Features.Forms.Commands.FormSubmissions.DeleteFormSubmission;
using Application.Features.Forms.Commands.FormSubmissions.UpdateFormSubmissions;
using Application.Features.Forms.Commands.ReviewComments.UpdateReviewComments;
using Application.Features.Forms.Commands.UpdateNewForm;
using Application.Features.Forms.Queries.FormSubmissions.GetFormSubmissions;
using Application.Features.Forms.Queries.GetNewForm.GetNewDepartmentForm;
using Application.Features.Forms.Queries.GetNewForm.GetNewIndividualForm;
using Application.Features.Forms.Queries.GetSavedForm;
using Application.Features.Forms.Queries.GetSavedForm.GetSavedCreativityForm;
using Application.Features.Forms.Queries.GetSavedForm.GetSavedDistinguishedManagementForm;
using Application.Features.Forms.Queries.ReviewComments.GetReviewComments;
using Application.Features.Forms.Queries.Statuses;
using Application.Models.Common;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrizeWebAPI.Models;


namespace PrizeWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FormController(
            IUpdateReviewCommentCommandHandler reviewCommentUpdateHandler,
            IGetReviewCommentQueryHandler reviewCommentQueryHandler,
            IGetFormSubmissionQueryHandler formSubmissionQueryHandler,
            IUpdateFormSubmissionCommandHandler formSubmissionUpdateHandler,
            IGetNewDepartmentFormQueryHandler departmentFormQueryHandler,
            IGetSavedFormQueryHandler savedFormQueryHandler,
            IGetSavedCreativityFormQueryHandler savedCreativityFormQueryHandler,
            IGetSavedDistinguishedManagementFormQueryHandler savedDistinguishedFormQueryHandler,
            IGetStatusesQueryHandler statusQueryHandler,
            ICreateNewFormCommandHandler newFormCommandHandler,
            IUpdateFormCommandHandler updateFormCommandHandler,
            IGetNewIndividualFormQueryHandler individualFormQueryHandler,
            IGetSubmittedAttachmentsQueryHandler submittedAttachmentsQueryHandler,
            IMapper mapper,
            IAuthService authService,
            IConfiguration configuration,
            IUserService userService,
            INotificationService notification,
            IDeleteFormSubmissionCommandHandler deleteFormSubmissionHandler
            ) : ControllerBase
    {
        private readonly IUpdateReviewCommentCommandHandler _reviewCommentUpdateHandler = reviewCommentUpdateHandler;
        private readonly IGetReviewCommentQueryHandler _reviewCommentQueryHandler = reviewCommentQueryHandler;
        private readonly IGetFormSubmissionQueryHandler _formSubmissionQueryHandler = formSubmissionQueryHandler;
        private readonly IUpdateFormSubmissionCommandHandler _formSubmissionUpdateHandler = formSubmissionUpdateHandler;
        private readonly IGetNewDepartmentFormQueryHandler _departmentFormQueryHandler = departmentFormQueryHandler;
        private readonly IGetSavedFormQueryHandler _savedFormQueryHandler = savedFormQueryHandler;
        private readonly IGetSavedCreativityFormQueryHandler _savedCreativityFormQueryHandler = savedCreativityFormQueryHandler;
        private readonly IGetSavedDistinguishedManagementFormQueryHandler _savedDistinguishedFormQueryHandler = savedDistinguishedFormQueryHandler;
        private readonly IGetStatusesQueryHandler _statusQueryHandler = statusQueryHandler;
        private readonly ICreateNewFormCommandHandler _newFormCommandHandler = newFormCommandHandler;
        private readonly IUpdateFormCommandHandler _updateFormCommandHandler = updateFormCommandHandler;
        private readonly IGetNewIndividualFormQueryHandler _individualFormQueryHandler = individualFormQueryHandler;
        private readonly IGetSubmittedAttachmentsQueryHandler _submittedAttachmentsQueryHandler = submittedAttachmentsQueryHandler;
        private readonly IMapper _mapper = mapper;
        private readonly IAuthService _authService = authService;
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserService _userService = userService;
        private readonly INotificationService _notification = notification;

        // Handler for deleting draft form submissions
        private readonly IDeleteFormSubmissionCommandHandler _deleteFormSubmissionHandler = deleteFormSubmissionHandler;

        [HttpGet]
        public async Task<ActionResult<ApiResponse<DepartmentFormDTO>>> GetNewDepartmentForm()
        {
            try
            {
                GetNewDepartmentFormQueryModel query = new GetNewDepartmentFormQueryModel { FormCategoryId = (int)FormCategoryEnum.Department };
                GetNewDepartmentFormQueryResult queryResult = await _departmentFormQueryHandler.HandleAsync(query);
                //FormSectionDTO result = _mapper.Map<FormSectionDTO>(queryResult);
                DepartmentFormDTO result = _mapper.Map<DepartmentFormDTO>(queryResult);

                if (result == null)
                {
                    return NotFound(new ApiResponse<DepartmentFormDTO>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<DepartmentFormDTO>
                {
                    Success = true,
                    Message = "Department Category Form retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<DepartmentFormDTO>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Department Category Form .",
                    Error = ex.Message
                });
            }
        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse<IndividualFormDTO>>> GetNewIndividualForm()
        {
            try
            {
                GetNewIndividualFormQueryModel query = new GetNewIndividualFormQueryModel { FormCategoryId = (int)FormCategoryEnum.Individual };
                GetNewIndividualFormQueryResult queryResult = await _individualFormQueryHandler.HandleAsync(query);
                IndividualFormDTO result = _mapper.Map<IndividualFormDTO>(queryResult);

                if (result == null)
                {
                    return NotFound(new ApiResponse<IndividualFormDTO>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<IndividualFormDTO>
                {
                    Success = true,
                    Message = "Individual Category Form retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<IndividualFormDTO>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Individual Category Form .",
                    Error = ex.Message
                });
            }
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse<FormSubmissionDTO>>> CreateNewFormRequest([FromForm] FormSubmissionDTO formSubmissionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();

                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Validation failed.",
                        Error = string.Join(" | ", errors)
                    });
                }

                ResponseResult<SAPUserInfoModel> userDetails = await _userService.GetUserDetails(formSubmissionDto.UserId);
                formSubmissionDto.DepartmentId = userDetails?.Model?.DepartmentCode ?? null;
                formSubmissionDto.DepartmentNameAr = userDetails?.Model?.DepartmentNameAr ?? null;
                formSubmissionDto.ApplicantFullNameAr = userDetails?.Model?.EmployeeName ?? null;

                //if (formSubmissionDto.CategoryId.Equals((int)FormCategoryEnum.Department))
                //{
                //    bool CheckAllowances = await _formSubmissionQueryHandler.HandleValidateDepartmentSubmissionLimit(formSubmissionDto.DepartmentId);
                //    if (CheckAllowances == true)
                //    {
                //        return BadRequest(new ApiResponse<object>
                //        {
                //            Success = false,
                //            Message = "فشل في حفظ التطبيق.",
                //            Error = "لقد تم تقديم الطلب بالفعل من قبل قسمك."
                //        });
                //    }
                //}

                if (formSubmissionDto.CategoryId.Equals((int)FormCategoryEnum.Individual))
                {
                    bool CheckAllowances = await _formSubmissionQueryHandler.HandleValidateIndividualSubmissionLimit(formSubmissionDto.UserId);
                    if (CheckAllowances == true)
                    {
                        return BadRequest(new ApiResponse<object>
                        {
                            Success = false,
                            Message = "فشل في حفظ التطبيق.",
                            Error = "لقد قمت بالفعل بتقديم 3 طلبات."
                        });
                    }
                }

                if (formSubmissionDto.SubmittedAttachments != null && formSubmissionDto.SubmittedAttachments.Count() > 0)
                {
                    //save attachments
                    foreach (var attachment in formSubmissionDto.SubmittedAttachments)
                    {
                        IFormFile file = attachment.File;
                        if (file == null || file.Length == 0) continue;
                        //return BadRequest("File is empty or not provided.");

                        var folderName = formSubmissionDto.CategoryId.Equals((int)FormCategoryEnum.Department)
                            ? _configuration["AppSettings:DistinguishedManagementCategoryAttachmentsDirectory"]
                            : _configuration["AppSettings:CreativityCategoryAttachmentsDirectory"];

                        // Define the target directory (can be relative or absolute)
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), folderName?.ToString());

                        // Create directory if it doesn't exist
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Generate a safe filename (optional: add timestamp or GUID)
                        var uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        var filePath = Path.Combine(uploadsFolder, uniqueName);

                        // Save the file
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        attachment.FilePath = filePath;
                        attachment.FileName = uniqueName;

                    }
                    //save attachments end

                }
                CreateNewFormCommandModel command = new CreateNewFormCommandModel
                {
                    submission = _mapper.Map<FormSubmission>(formSubmissionDto),
                    answers = _mapper.Map<List<SubmittedAnswer>>(formSubmissionDto.SubmittedAnswers),
                    attachments = _mapper.Map<List<SubmittedAttachment>>(formSubmissionDto.SubmittedAttachments),
                    participants = _mapper.Map<List<Participant>?>(formSubmissionDto.Participants),
                };

                CreateNewFormCommandResult commandResult = await _newFormCommandHandler.HandleAsync(command);

                FormSubmissionDTO result = new FormSubmissionDTO();
                result = _mapper.Map<FormSubmissionDTO>(commandResult.submission);
                result.SubmittedAnswers = _mapper.Map<List<SubmittedAnswerDTO>>(commandResult.answers);
                result.SubmittedAttachments = _mapper.Map<List<SubmittedAttachmentDTO>>(commandResult.attachments);
                result.Participants = _mapper.Map<List<ParticipantDTO>?>(commandResult.particpants);

                return CreatedAtAction(nameof(CreateNewFormRequest), new { id = formSubmissionDto.Id }, new ApiResponse<FormSubmissionDTO>
                {
                    Success = true,
                    Message = "New form created successfully.",
                    Data = result
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<FormSubmissionDTO>
                {
                    Success = false,
                    Message = "An error occurred while creating new form.",
                    Error = ex.Message
                });
            }
        }


        [HttpPut]
        [RequestSizeLimit(2L * 1024 * 1024 * 1024)] // 2 GB
        public async Task<ActionResult<ApiResponse<FormSubmissionDTO>>> UpdateFormRequest([FromForm] FormSubmissionDTO formSubmissionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();

                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Validation failed.",
                        Error = string.Join(" | ", errors)
                    });
                }

                ResponseResult<SAPUserInfoModel> applicantDetails = await _userService.GetUserDetails(formSubmissionDto.UserId);
                formSubmissionDto.DepartmentId = applicantDetails?.Model?.DepartmentCode ?? null;
                formSubmissionDto.DepartmentNameAr = applicantDetails?.Model?.DepartmentNameAr ?? null;
                formSubmissionDto.ApplicantFullNameAr = applicantDetails?.Model?.EmployeeName ?? null;

                if (formSubmissionDto.SubmittedAttachments != null && formSubmissionDto.SubmittedAttachments.Count > 0)
                {
                    // save attachments

                    foreach (var attachment in formSubmissionDto.SubmittedAttachments)
                    {
                        IFormFile file = attachment.File;
                        if (file == null || file.Length == 0) continue;
                        //return BadRequest("File is empty or not provided.");

                        var folderName = formSubmissionDto.CategoryId.Equals((int)FormCategoryEnum.Department)
                            ? _configuration["AppSettings:DistinguishedManagementCategoryAttachmentsDirectory"]
                            : _configuration["AppSettings:CreativityCategoryAttachmentsDirectory"];

                        // Define the target directory (can be relative or absolute)
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), folderName?.ToString());

                        // Create directory if it doesn't exist
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Generate a safe filename (optional: add timestamp or GUID)
                        var uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        var filePath = Path.Combine(uploadsFolder, uniqueName);

                        // Save the file
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        attachment.FilePath = filePath;
                        attachment.FileName = uniqueName;

                    }
                    //save attachments end

                }

                UpdateFormCommandModel command = new UpdateFormCommandModel
                {
                    submission = _mapper.Map<FormSubmission>(formSubmissionDto),
                    answers = _mapper.Map<List<SubmittedAnswer>>(formSubmissionDto.SubmittedAnswers),
                    attachments = _mapper.Map<List<SubmittedAttachment>>(formSubmissionDto.SubmittedAttachments),
                    particpants = _mapper.Map<List<Participant>?>(formSubmissionDto.Participants),
                };

                UpdateFormCommandResult commandResult = await _updateFormCommandHandler.HandleAsync(command);

                FormSubmissionDTO result = new FormSubmissionDTO();
                result = _mapper.Map<FormSubmissionDTO>(commandResult.submission);
                result.SubmittedAnswers = _mapper.Map<List<SubmittedAnswerDTO>>(commandResult.answers);
                result.SubmittedAttachments = _mapper.Map<List<SubmittedAttachmentDTO>>(commandResult.attachments);
                result.Participants = _mapper.Map<List<ParticipantDTO>?>(commandResult.particpants);

                if (result.IsSubmitted)
                {
                    var userDetails = await _userService.GetUserDetails(result.UserId);

                    var ReciverEmail = new List<string>();

                    if (userDetails != null)
                        ReciverEmail = new List<string> { userDetails?.Model?.Email?.ToString() ?? "" };

                    if (ReciverEmail != null && ReciverEmail.Count() > 0)
                    {
                        await _notification.SendAsync(new NotificationMessageModel()
                        {
                            Content = { },
                            ViewName = "msg.cshtml",
                            Subject = "جائزة الهيئة للتميز",
                            To = ReciverEmail ?? []
                        });
                    }
                }

                return Ok(new ApiResponse<FormSubmissionDTO>
                {
                    Success = true,
                    Message = "Form updated successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<FormSubmissionDTO>
                {
                    Success = false,
                    Message = "An error occurred while updating form.",
                    Error = ex.Message
                });
            }
        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse<SavedFormDTO>>> GetSavedForm([FromQuery] int submissionId)
        {
            try
            {
                GetSavedFormQueryModel query = new GetSavedFormQueryModel { FormSubmissionId = submissionId };
                GetSavedFormQueryResult queryResult = await _savedFormQueryHandler.HandleAsync(query);
                //FormSubmissionDTO result = _mapper.Map<FormSubmissionDTO>(queryResult);
                SavedFormDTO result = _mapper.Map<SavedFormDTO>(queryResult);

                if (result == null)
                {
                    return NotFound(new ApiResponse<SavedFormDTO>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<SavedFormDTO>
                {
                    Success = true,
                    Message = "Saved Form retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<SavedFormDTO>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Saved Form .",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<SavedCreativityFormDTO>>> GetSavedCreativityForm([FromQuery] int submissionId)
        {
            try
            {
                GetSavedCreativityFormQueryModel query = new GetSavedCreativityFormQueryModel { FormSubmissionId = submissionId };
                GetSavedCreativityFormQueryResult queryResult = await _savedCreativityFormQueryHandler.HandleAsync(query);
                //FormSubmissionDTO result = _mapper.Map<FormSubmissionDTO>(queryResult);
                SavedCreativityFormDTO result = _mapper.Map<SavedCreativityFormDTO>(queryResult);

                if (result == null)
                {
                    return NotFound(new ApiResponse<SavedCreativityFormDTO>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<SavedCreativityFormDTO>
                {
                    Success = true,
                    Message = "Saved Creativity Form retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<SavedCreativityFormDTO>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Saved Creativity Form .",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<SavedDistinguishedManagementFormDTO>>> GetSavedDistinguishedManagementForm([FromQuery] int submissionId)
        {
            try
            {
                GetSavedDistinguishedManagementFormQueryResult queryResult = await _savedDistinguishedFormQueryHandler.HandleAsync(submissionId);
                SavedDistinguishedManagementFormDTO result = _mapper.Map<SavedDistinguishedManagementFormDTO>(queryResult);

                if (result == null)
                {
                    return NotFound(new ApiResponse<SavedDistinguishedManagementFormDTO>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<SavedDistinguishedManagementFormDTO>
                {
                    Success = true,
                    Message = "Saved Distinguished Management Form retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<SavedDistinguishedManagementFormDTO>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Saved Distinguished Management Form .",
                    Error = ex.Message
                });
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<FormSubmissionDTO>>> GetUserSubmissionsList([FromQuery] string UserID)
        {
            try
            {
                var queryResult = await _formSubmissionQueryHandler.HandleGetUserSubmissionsAsync(UserID);
                List<FormSubmissionDTO> result = _mapper.Map<List<FormSubmissionDTO>>(queryResult);

                if (result.Count == 0)
                {
                    return NotFound(new ApiResponse<List<FormSubmissionDTO>>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<List<FormSubmissionDTO>>
                {
                    Success = true,
                    Message = "Data retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<List<FormSubmissionDTO>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving User Submitted Forms.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<FormSubmissionDTO>>> GetDepartmentSubmissionsList([FromQuery] string DepartmentId)
        {
            try
            {
                var queryResult = await _formSubmissionQueryHandler.HandleGetDepartmentSubmissionsAsync(DepartmentId);
                List<FormSubmissionDTO> result = _mapper.Map<List<FormSubmissionDTO>>(queryResult);

                if (result.Count == 0)
                {
                    return NotFound(new ApiResponse<List<FormSubmissionDTO>>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<List<FormSubmissionDTO>>
                {
                    Success = true,
                    Message = "Data retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<List<FormSubmissionDTO>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Department Submitted Forms.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<DashboardListDTO>>>> GetFormSubmissionsByUserId([FromQuery] string userId)
        {
            try
            {
                var queryResult = await _formSubmissionQueryHandler.HandleGetFormSubmissionsByUserIdAsync(userId);
                List<DashboardListDTO> result = _mapper.Map<List<DashboardListDTO>>(queryResult);

                if (result.Count == 0)
                {
                    return NotFound(new ApiResponse<List<DashboardListDTO>>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<List<DashboardListDTO>>
                {
                    Success = true,
                    Message = "Data retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<List<DashboardListDTO>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Submitted Forms List.",
                    Error = ex.Message
                });
            }
        }


        [HttpGet]
        public async Task<IActionResult> ViewFile([FromQuery] int submittedAttachmentId)
        {
            var attachment = await _submittedAttachmentsQueryHandler.HandleAsync(submittedAttachmentId);
            if (attachment == null || !System.IO.File.Exists(attachment.FilePath))
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"No file was found."
                });

            var fileBytes = await System.IO.File.ReadAllBytesAsync(attachment.FilePath);
            var contentType = GetContentType(attachment.FileName) ?? "application/octet-stream";

            var fileDto = new FileResponseDTO
            {
                FileName = attachment.FileName,
                ContentType = contentType,
                FileBytes = fileBytes
            };

            return Ok(new ApiResponse<FileResponseDTO>
            {
                Success = true,
                Message = "File retrieved successfully.",
                Data = fileDto
            });
            //return File(fileBytes, contentType);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile([FromQuery] int submittedAttachmentId)
        {
            var attachment = await _submittedAttachmentsQueryHandler.HandleAsync(submittedAttachmentId);
            if (attachment == null || !System.IO.File.Exists(attachment.FilePath))
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"No file was found."
                });

            var fileBytes = await System.IO.File.ReadAllBytesAsync(attachment.FilePath);
            var contentType = GetContentType(attachment.FileName) ?? "application/octet-stream";

            return File(fileBytes, contentType, attachment.FileName);

        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<AdminDashboardListDTO>>>> GetDepartmentFormsForAdminDashboard([FromQuery] string? statusId, int? submissionId, string? applicantName, string? departmentName)
        {
            try
            {
                var queryResult = await _formSubmissionQueryHandler.HandleGetDepartmentFormsForAdminDashboardAsync(statusId, submissionId, applicantName, departmentName);
                List<AdminDashboardListDTO> result = _mapper.Map<List<AdminDashboardListDTO>>(queryResult);

                if (result.Count == 0)
                {
                    return Ok(new ApiResponse<List<AdminDashboardListDTO>>
                    {
                        Success = false,
                        Message = $"No data was found.",
                        Data = result
                    });
                }

                return Ok(new ApiResponse<List<AdminDashboardListDTO>>
                {
                    Success = true,
                    Message = "Data retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<List<AdminDashboardListDTO>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Forms List for Department Category.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<AdminDashboardListDTO>>>> GetIndividualFormsForAdminDashboard([FromQuery] string? statusId, int? submissionId, string? applicantName, string? departmentName)
        {
            try
            {
                var queryResult = await _formSubmissionQueryHandler.HandleGetIndividualFormsForAdminDashboardAsync(statusId, submissionId, applicantName, departmentName);
                List<AdminDashboardListDTO> result = _mapper.Map<List<AdminDashboardListDTO>>(queryResult);

                if (result.Count == 0)
                {
                    return Ok(new ApiResponse<List<AdminDashboardListDTO>>
                    {
                        Success = false,
                        Message = $"No data was found.",
                        Data = result
                    });
                }

                return Ok(new ApiResponse<List<AdminDashboardListDTO>>
                {
                    Success = true,
                    Message = "Data retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<List<AdminDashboardListDTO>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Forms List For Individual Category.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<StatusDTO>>>> GetFormStatuses()
        {
            try
            {
                var queryResult = await _statusQueryHandler.HandleGetAllStatusesAsync();
                List<StatusDTO> result = _mapper.Map<List<StatusDTO>>(queryResult);

                if (result.Count == 0)
                {
                    return NotFound(new ApiResponse<List<StatusDTO>>
                    {
                        Success = false,
                        Message = $"No data was found."
                    });
                }

                return Ok(new ApiResponse<List<StatusDTO>>
                {
                    Success = true,
                    Message = "Data retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<List<StatusDTO>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Form Statuses.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<FormSubmissionDTO>>> ApproveFormRequest(int submissionId)
        {
            try
            {
                var queryResult = await _formSubmissionUpdateHandler.HandleFormRequestApprovalAsync(submissionId);

                if (queryResult == null)
                {
                    return NotFound(new ApiResponse<FormSubmissionDTO>
                    {
                        Success = false,
                        Message = $"Application with Id: {submissionId} does not exist."
                    });
                }

                FormSubmissionDTO result = _mapper.Map<FormSubmissionDTO>(queryResult);

                if (result.StatusId.Equals((int)FormStatusEnum.Accepted))
                {
                    var userDetails = await _userService.GetUserDetails(result.UserId);

                    var ReceiverEmail = new List<string>();

                    if (userDetails != null)
                        ReceiverEmail = new List<string> { userDetails?.Model?.Email?.ToString() ?? "" };

                    if (ReceiverEmail != null && ReceiverEmail.Count() > 0)
                    {
                        await _notification.SendAsync(new NotificationMessageModel()
                        {
                            Content = new Dictionary<string, object>() { { "SubmissionId", result.Id.ToString() } },
                            ViewName = "Accepted.cshtml",
                            Subject = " تم قبول الطلب - جائزة الهيئة للتميز",
                            To = ReceiverEmail ?? []
                        });
                    }
                }

                return Ok(new ApiResponse<FormSubmissionDTO>
                {
                    Success = true,
                    Message = "Form approved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<FormSubmissionDTO>
                {
                    Success = false,
                    Message = "An error occurred while approving Form.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<FormSubmissionDTO>>> RejectFormRequest(int submissionId)
        {
            try
            {
                var queryResult = await _formSubmissionUpdateHandler.HandleFormRequestRejectionAsync(submissionId);

                if (queryResult == null)
                {
                    return NotFound(new ApiResponse<FormSubmissionDTO>
                    {
                        Success = false,
                        Message = $"Application with Id: {submissionId} does not exist."
                    });
                }

                FormSubmissionDTO result = _mapper.Map<FormSubmissionDTO>(queryResult);

                if (result.StatusId.Equals((int)FormStatusEnum.Denied))
                {
                    var userDetails = await _userService.GetUserDetails(result.UserId);

                    var ReceiverEmail = new List<string>();

                    if (userDetails != null)
                        ReceiverEmail = new List<string> { userDetails?.Model?.Email?.ToString() ?? "" };

                    if (ReceiverEmail != null && ReceiverEmail.Count() > 0)
                    {
                        await _notification.SendAsync(new NotificationMessageModel()
                        {
                            Content = new Dictionary<string, object>() { { "SubmissionId", result.Id.ToString() } },
                            ViewName = "Denied.cshtml",
                            Subject = "تم رفض الطلب - جائزة الهيئة للتميز",
                            To = ReceiverEmail ?? []
                        });
                    }
                }

                return Ok(new ApiResponse<FormSubmissionDTO>
                {
                    Success = true,
                    Message = "Form rejected successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<FormSubmissionDTO>
                {
                    Success = false,
                    Message = "An error occurred while rejecting Form.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<FormSubmissionDTO>>> ReturnFormForModification(int submissionId)
        {
            try
            {
                var queryResult = await _formSubmissionUpdateHandler.HandleReturnFormForModificationAsync(submissionId);

                if (queryResult == null)
                {
                    return NotFound(new ApiResponse<FormSubmissionDTO>
                    {
                        Success = false,
                        Message = $"Application with Id: {submissionId} does not exist."
                    });
                }

                FormSubmissionDTO result = _mapper.Map<FormSubmissionDTO>(queryResult);

                if (result.StatusId.Equals((int)FormStatusEnum.Reset))
                {
                    var userDetails = await _userService.GetUserDetails(result.UserId);

                    var ReceiverEmail = new List<string>();

                    if (userDetails != null)
                        ReceiverEmail = new List<string> { userDetails?.Model?.Email?.ToString() ?? "" };

                    if (ReceiverEmail != null && ReceiverEmail.Count() > 0)
                    {
                        await _notification.SendAsync(new NotificationMessageModel()
                        {
                            Content = new Dictionary<string, object>() { { "SubmissionId", result.Id.ToString() } },
                            ViewName = "Reset.cshtml",
                            Subject = "تم إرجاع الطلب للتعديل - جائزة الهيئة للتميز",
                            To = ReceiverEmail ?? []
                        });
                    }
                }

                return Ok(new ApiResponse<FormSubmissionDTO>
                {
                    Success = true,
                    Message = "Form sent for modification successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<FormSubmissionDTO>
                {
                    Success = false,
                    Message = "An error occurred while sending form for modification.",
                    Error = ex.Message
                });
            }
        }

        /// Deletes a draft form submission belonging to the current user. Only drafts 
        [HttpDelete]
        public async Task<IActionResult> DeleteFormRequest([FromQuery] int submissionId)
        {
            try
            {
                bool isValid = _authService.ValidateToken(out string uid, out string fullName);
                if (!isValid)
                {
                    return new UnauthorizedObjectResult(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Unauthorized Access"
                    });
                }

                bool deleted = await _deleteFormSubmissionHandler.HandleAsync(submissionId);
                if (!deleted)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = $"Draft with Id: {submissionId} not found or cannot be deleted."
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Draft deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An error occurred while deleting the draft.",
                    Error = ex.Message
                });
            }
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse<ReviewCommentDTO>>> SaveFormReviewComment([FromForm] ReviewCommentDTO reviewCommentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();

                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Validation failed.",
                        Error = string.Join(" | ", errors)
                    });
                }

                var reviewCommentModel = _mapper.Map<ReviewComment>(reviewCommentDTO);

                ReviewComment? commandResult = await _reviewCommentUpdateHandler.HandleSaveReviewCommentAsync(reviewCommentModel);

                ReviewCommentDTO result = new ReviewCommentDTO();
                result = _mapper.Map<ReviewCommentDTO>(commandResult);

                return Ok(new ApiResponse<ReviewCommentDTO>
                {
                    Success = true,
                    Message = "Review comment saved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<ReviewCommentDTO>
                {
                    Success = false,
                    Message = "An error occurred while saving review comment.",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ReviewCommentDTO>>>> GetFormReviewComments(int submissionId)
        {
            try
            {
                var queryResult = await _reviewCommentQueryHandler.HandleGetReviewCommentForResetStatusAsync(submissionId);

                if (queryResult == null)
                {
                    return NotFound(new ApiResponse<List<ReviewCommentDTO>>
                    {
                        Success = false,
                        Message = $"Application with Id: {submissionId} does not exist."
                    });
                }

                List<ReviewCommentDTO> result = _mapper.Map<List<ReviewCommentDTO>>(queryResult);

                if (result.Count == 0)
                {
                    return Ok(new ApiResponse<List<ReviewCommentDTO>>
                    {
                        Success = false,
                        Message = $"No data was found.",
                        Data = result
                    });
                }

                return Ok(new ApiResponse<List<ReviewCommentDTO>>
                {
                    Success = true,
                    Message = "Form review comments retrieved successfully.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<List<ReviewCommentDTO>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving Form review comments.",
                    Error = ex.Message
                });
            }
        }

        private string GetContentType(string fileName)
        {
            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out string contentType))
            {
                contentType = "application/octet-stream"; // fallback
            }
            return contentType;
        }

    }
}
