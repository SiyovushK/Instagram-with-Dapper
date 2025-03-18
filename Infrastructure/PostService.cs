using Dapper;
using Npgsql;
using Domain.Entities;
using Domain.DTOs;
namespace Infrastructure;

public class PostService
{
    private const string connectionString = "Host=localhost; Username=postgres; Password=Fa1konm1; Database=Insta";

    //Task 3
    public List<Special> GetUsersPosts(int userID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT p.PostId, p.UserId, p.Content, p.CreationDate,
                COUNT(l.LikeId) AS LikesCount,
                COUNT(c.CommentId) AS CommentCount
            FROM Posts p
            JOIN Likes l ON l.PostId = p.PostId
            JOIN Comments c ON c.PostId = p.PostId
            WHERE p.UserId = @UserID
            GROUP BY p.PostId
        ";
        var result = connection.Query<Special>(sql, new {UserID = userID}).ToList();

        return result;
    }

    //Task 4
    public List<Special> GetToFivePosts()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT p.PostId, p.UserId, p.Content, p.CreationDate,
                COUNT(l.LikeId) AS LikesCount,
                COUNT(c.CommentId) AS CommentCount
            FROM Posts p
            JOIN Likes l ON l.PostId = p.PostId
            JOIN Comments c ON c.PostId = p.PostId
            GROUP BY p.PostId
            ORDER BY LikesCount DESC, CommentsCount LIMIT 5
        ";
        var result = connection.Query<Special>(sql).ToList();

        return result;
    }

    //Task 5
    public List<Special> GetPostAboveThreeComments()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT p.PostId, p.UserId, p.Content, p.CreationDate,
                COUNT(c.CommentId) AS CommentsCount
            FROM Posts p
            JOIN Comments c ON c.PostId = p.PostId
            GROUP BY p.PostId
            HAVING COUNT(c.CommentId) > 3
        ";
        var result = connection.Query<Special>(sql).ToList();

        return result;
    }

    public int AddPost(Posts post)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            INSERT INTO Posts(PostId, UserId, Content, CreationDate, LikesCount)
            VALUES
            (@PostId, @UserId, @Content, @CreationDate, @LikesCount)
        ";
        var result = connection.Execute(sql, post);

        return result;
    }

    public List<Posts> GetAllPosts()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT *
            FROM Posts
        ";
        var result = connection.Query<Posts>(sql).ToList();

        return result;
    }

    public Posts GetSpecificPost(int postID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT *
            FROM Posts
            WHERE PostId = @PostID
        ";
        var result = connection.QueryFirstOrDefault<Posts>(sql, new {PostID = postID});

        return result;
    }

    public int UpdatePost(Posts post)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            UPDATE Posts
            SET UserId=@UserId, Content=@Content, CreationDate=@CreationDate, LikesCount=@LikesCount
            WHERE PostId = @PostId
        ";
        var result = connection.Execute(sql, post);

        return result;
    }

    public int DeletePost(int PostID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            DELETE 
            FROM Posts
            WHERE PostId = @PostID
        ";
        var result = connection.Execute(sql, new {PostID = PostID});

        return result;
    }
}