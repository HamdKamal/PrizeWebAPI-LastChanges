namespace Core.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(NotificationMessageModel message);
    }
}

public class NotificationMessageModel
{
    public string ViewName { get; set; }
    public string From { get; set; }
    public List<string> To { get; set; }
    public List<string> CC { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public IDictionary<string, object> Content { get; set; }
}

