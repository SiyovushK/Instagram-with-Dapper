namespace Domain.Entities;

public class Likes
{
    public int LikeId { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public DateTime LikeDate { get; set; }
}