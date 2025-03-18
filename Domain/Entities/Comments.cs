namespace Domain.Entities;

public class Comments
{
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string? Content { get; set; }
    public DateTime CreationDate { get; set; }
}