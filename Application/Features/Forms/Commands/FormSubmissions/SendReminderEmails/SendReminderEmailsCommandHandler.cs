using Application.Abstractions.Common;
using Application.Models.Common;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.FormSubmissions.SendReminderEmails
{
    public class SendReminderEmailsCommandHandler : ISendReminderEmailsCommandHandler
    {
        private readonly IFormSubmissionRepository _formSubmissionRepository;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;

        public SendReminderEmailsCommandHandler(
            IFormSubmissionRepository formSubmissionRepository,
            IUserService userService,
            INotificationService notificationService)
        {
            _formSubmissionRepository = formSubmissionRepository;
            _userService = userService;
            _notificationService = notificationService;
        }

        public async Task<int> HandleAsync(DateTime deadline)
        {
            DateTime today = DateTime.Today;
            if ((deadline.Date - today).TotalDays > 7)
            {
                // Not yet time to send reminders; return 0 to indicate no messages were dispatched.
                return 0;
            }

            var pendingSubmissions = await _formSubmissionRepository.GetPendingSubmissionsForReminderAsync();
            var groupedByUser = pendingSubmissions
                .GroupBy(f => f.UserId)
                .ToList();

            int remindersSent = 0;

            foreach (var group in groupedByUser)
            {
                string userId = group.Key;
                var userDetailsResponse = await _userService.GetUserDetails(userId);
                string? email = userDetailsResponse?.Model?.Email;
                if (string.IsNullOrWhiteSpace(email))
                {
                    continue;
                }

                int anySubmissionId = group.First().Id;
                var message = new NotificationMessageModel
                {
                    ViewName = "Reminder.cshtml",
                    Subject = "تنبيه بموعد إغلاق استقبال الطلبات",
                    To = [email],
                    Content = new Dictionary<string, object>
                    {
                        { "SubmissionId", anySubmissionId.ToString() },
                        { "Deadline", deadline.ToString("yyyy-MM-dd") }
                    }
                };
                await _notificationService.SendAsync(message);
                remindersSent++;
            }

            return remindersSent;
        }
    }
}