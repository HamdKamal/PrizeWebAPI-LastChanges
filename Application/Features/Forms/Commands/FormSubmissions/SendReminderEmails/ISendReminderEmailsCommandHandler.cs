using System;
using System.Threading.Tasks;

namespace Application.Features.Forms.Commands.FormSubmissions.SendReminderEmails
{
    public interface ISendReminderEmailsCommandHandler
    {
        Task<int> HandleAsync(DateTime deadline);
    }
}