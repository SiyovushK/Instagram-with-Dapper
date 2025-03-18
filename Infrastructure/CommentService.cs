using Dapper;
using Npgsql;
using Domain.Entities;
namespace Infrastructure;

public class CommentService
{
    private const string connectionString = "Host=localhost; Username=postgres; Password=Fa1konm1; Database=Insta";

    public int AddComment(Comments comment)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            INSERT INTO Comments(CommentId, UserId, PostId, Content, CreationDate)
            VALUES
            (@CommentId, @UserId, @PostId, @Content, @CreationDate)
        ";
        var result = connection.Execute(sql, comment);

        return result;
    }

    public List<Comments> GetCommentsOnPost(int postID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT *
            FROM Comments
            WHERE PostId = @PostID
        ";
        var result = connection.Query<Comments>(sql, new {PostID = postID}).ToList();

        return result;
    }

    public int DeleteComment(int PostID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            DELETE 
            FROM Comments
            WHERE PostId = @postID
        ";
        var result = connection.Execute(sql, new {postID = PostID});

        return result;
    }
}