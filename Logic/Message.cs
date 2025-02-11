namespace Logic;

public record Message
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public string Username { get; set; } = "";
    public DateTime TimePosted { get; set; }
}
