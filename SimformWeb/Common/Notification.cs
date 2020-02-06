using System.ComponentModel;

namespace SimformWeb.Common
{
    public enum NotificationType
    {
        [Description("Success")]
        Success = 1,

        [Description("Error")]
        Error = 2
    }

    public class Notification
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}