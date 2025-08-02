using Application.Models.Common;
using Core.Interfaces;
using System.Net.Mail;

namespace Infrastructure.Services
{
    public class EmailNotificationService : INotificationService
    {
        private readonly EmailConfigurationModel _emailConfigurationModel;
        private readonly IViewRendererService _viewRendererService;

        public EmailNotificationService(EmailConfigurationModel emailConfigurationModel, IViewRendererService viewRendererService)
        {
            _emailConfigurationModel = emailConfigurationModel;
            _viewRendererService = viewRendererService;
        }
        public async Task SendAsync(NotificationMessageModel message)
        {
            if (_emailConfigurationModel.SendingEmailEnabled)
            {
                var html = await _viewRendererService.RenderPartialToStringAsync("Views/" + message.ViewName, message);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_emailConfigurationModel.From, message.Subject);

                if (message.To != null)
                {
                    foreach (var item in message.To)
                        mail.To.Add(new MailAddress(item));
                }
                if (message.CC != null)
                {
                    foreach (var item in message.CC)
                        mail.CC.Add(new MailAddress(item));
                }

                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Port = _emailConfigurationModel.Port;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = true;
                client.Host = _emailConfigurationModel.SmtpServer;
                mail.Subject = message.Subject;
                mail.Body = html;
                await client.SendMailAsync(mail);

            }
        }
    }
}
