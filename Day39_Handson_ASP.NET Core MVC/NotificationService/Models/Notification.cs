namespace NotificationService.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}