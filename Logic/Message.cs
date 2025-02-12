namespace Logic;

public record Message
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public string Username { get; set; } = "";
    public DateTime TimePosted { get; set; }
    public int LamportNumber { get; set; } = 0;
    public string ProcessId { get; set; } = "";
}
