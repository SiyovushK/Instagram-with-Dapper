using Dapper;
using Npgsql;
using Domain.Entities;
using Domain.DTOs;
namespace Infrastructure;

public class LikeService
{
    private const string connectionString = "Host=localhost; Username=postgres; Password=Fa1konm1; Database=Insta";

    //Task 2
    public PostIdAndLikesCount GetLikesCount(int postID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT PostId, COUNT(*) AS LikesCount
            FROM Likes
            WHERE PostId = @PostID
            GROUP BY PostId
        ";
        var result = connection.QueryFirstOrDefault<PostIdAndLikesCount>(sql, new {PostID = postID});

        return result;
    }

    public int AddLike(Likes like)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            INSERT INTO Likes(LikeId, UserId, PostId, LikeDate)
            VALUES
            (@LikeId, @UserId, @PostId, @LikeDate)
        ";
        var result = connection.Execute(sql, like);

        return result;
    }

    public List<Likes> GetLikesOnPost(int postID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT *
            FROM Likes
            WHERE PostId = @PostID
        ";
        var result = connection.Query<Likes>(sql, new {PostID = postID}).ToList();

        return result;
    }

    public int DeleteLike(int PostID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            DELETE 
            FROM Likes
            WHERE PostId = @postID
        ";
        var result = connection.Execute(sql, new {postID = PostID});

        return result;
    }
}