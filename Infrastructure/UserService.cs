using Dapper;
using Npgsql;
using Domain.Entities;
namespace Infrastructure;

public class UserService
{
    private const string connectionString = "Host=localhost; Username=postgres; Password=Fa1konm1; Database=Insta";

    //Task 1
    public List<User> GetAllUsersSorted()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT *
            FROM Users
            ORDER BY RegistrationDate
        ";
        var result = connection.Query<User>(sql).ToList();

        return result;
    }

    public int AddUser(User user)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            INSERT INTO Users(UserId, Username, Email, FullName, RegistrationDate)
            VALUES
            (@UserId, @Username, @Email, @FullName, @RegistrationDate)
        ";
        var result = connection.Execute(sql, user);

        return result;
    }

    public List<User> GetAllUsers()
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT *
            FROM Users
        ";
        var result = connection.Query<User>(sql).ToList();

        return result;
    }

    public User GetSpecificUsers(int UserID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            SELECT *
            FROM Users
            WHERE UserId = @userID
        ";
        var result = connection.QueryFirstOrDefault<User>(sql, new {userID = UserID});

        return result;
    }

    public int UpdateUser(User user)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            UPDATE Users
            SET Username=@Username, Email=@Email, FullName=@FullName, RegistrationDate=@RegistrationDate
            WHERE UserId = @UserId
        ";
        var result = connection.Execute(sql, user);

        return result;
    }

    public int DeleteUser(int UserID)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var sql = @"
            DELETE 
            FROM Users
            WHERE UserId = @userID
        ";
        var result = connection.Execute(sql, new {userID = UserID});

        return result;
    }
}