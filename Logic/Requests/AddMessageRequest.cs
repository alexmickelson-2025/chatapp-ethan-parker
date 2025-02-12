namespace Logic.Requests;

public class AddMessageRequest
{
    public string Content { get; set; } = "";
    public string Username { get; set; } = "";
    public int LamportNumber { get; set; }
    public string ProcessId { get; set; } = "";
}