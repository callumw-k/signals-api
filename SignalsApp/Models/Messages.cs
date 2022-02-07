namespace SignalsApp.Models;

public class Message
{
    public int Id { get; set; }
    public string MessageTitle { get; set; }
    public string MessageBody { get; set; }
    public string? MessageLines { get; set; }
}