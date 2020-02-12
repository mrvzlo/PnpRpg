namespace Boot.Models
{
    public class StatusResult
    {
        public string Color, Message;

        public StatusResult(bool success, string message)
        {
            Color = success ? "success" : "danger";
            Message = message;
        }
    }
}