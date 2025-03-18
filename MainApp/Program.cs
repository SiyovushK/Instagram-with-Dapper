using Domain.Entities;
using Infrastructure;

UserService userService = new UserService();
PostService postService = new PostService();
LikeService likeService = new LikeService();
CommentService commentService = new CommentService();

while (true)
{
    try
    {
        System.Console.WriteLine();
        System.Console.WriteLine("-----USER-----");
        System.Console.WriteLine("1. Add user");
        System.Console.WriteLine("2. Get all users");
        System.Console.WriteLine("3. Get specific users");
        System.Console.WriteLine("4. Update user");
        System.Console.WriteLine("5. Delete user");
        System.Console.WriteLine("6. Get all users sorted");
        System.Console.WriteLine();
        System.Console.WriteLine("0. Exit");

        System.Console.Write("Choose an option: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            System.Console.WriteLine();

            System.Console.Write("User ID: ");
            int ID = int.Parse(Console.ReadLine());

            System.Console.Write("Username: ");
            string username = Console.ReadLine();

            System.Console.Write("Email: ");
            string email = Console.ReadLine();

            System.Console.Write("Full name: ");
            string fullName = Console.ReadLine();

            System.Console.Write("Registration date: ");
            DateTime registrationDate = DateTime.Parse(Console.ReadLine());

            User user = new User()
            {
                Username = username,
                Email = email,
                FullName = fullName,
                RegistrationDate = registrationDate
            }; 

            int result = userService.AddUser(user);
            if (result > 0)
            {
                System.Console.WriteLine("User added successefully");
            }
            else
            {
                System.Console.WriteLine("Error, user is not added");
            }
        }
        if (choice == 2)
        {
            System.Console.WriteLine();
            var users = userService.GetAllUsers();
            System.Console.WriteLine("User ID\tUsername\tEmail\t\t\tFull name\tRegistration date");
            foreach (var user in users)
            {
                System.Console.WriteLine($"{user.UserId}\t{user.Username}\t{user.Email}\t{user.FullName}\t{user.RegistrationDate:yyyy-MM-dd}");
            }
        }
        if (choice == 3)
        {
            System.Console.WriteLine();
            System.Console.Write("Enter User ID: ");
            int ID = int.Parse(Console.ReadLine());

            var user = userService.GetSpecificUsers(ID);
            if (user is null)
            {
                System.Console.WriteLine("User is not fount");
            }
            else
            {
                System.Console.WriteLine("User ID\tUsername\tEmail\t\t\tFull name\tRegistration date");
                System.Console.WriteLine($"{user.UserId}\t{user.Username}\t{user.Email}\t{user.FullName}\t{user.RegistrationDate:yyyy-MM-dd}");
            }
        }
        if (choice == 4)
        {
            System.Console.WriteLine();

            System.Console.Write("User ID: ");
            int ID = int.Parse(Console.ReadLine());

            System.Console.Write("Username: ");
            string username = Console.ReadLine();

            System.Console.Write("Email: ");
            string email = Console.ReadLine();

            System.Console.Write("Full name: ");
            string fullName = Console.ReadLine();

            System.Console.Write("Registration date: ");
            DateTime registrationDate = DateTime.Parse(Console.ReadLine());

            User user = new User()
            {
                UserId = ID,
                Username = username,
                Email = email,
                FullName = fullName,
                RegistrationDate = registrationDate
            }; 

            int result = userService.UpdateUser(user);
            if (result > 0)
            {
                System.Console.WriteLine("User updated successefully");
            }
            else
            {
                System.Console.WriteLine("Error, user is not updated");
            }
        }
        if (choice == 5)
        {
            System.Console.WriteLine();

            System.Console.Write("User ID: ");
            int ID = int.Parse(Console.ReadLine());

            var result = userService.DeleteUser(ID);
            if (result > 0)
            {
                System.Console.WriteLine("User deleted successefully");
            }
            else
            {
                System.Console.WriteLine("Error, user is not deleted");
            }
        }
        if (choice == 6)
        {
            System.Console.WriteLine();
            var result = userService.GetAllUsersSorted();
            System.Console.WriteLine("User ID\tUsername\tEmail\t\t\tFull name\tRegistration date");
            foreach (var user in result)
            {
                System.Console.WriteLine($"{user.UserId}\t{user.Username}\t{user.Email}\t{user.FullName}\t{user.RegistrationDate:yyyy-MM-dd}");
            }
        }
        if (choice == 0)
        {
            System.Console.WriteLine("Exiting, bye!");
            break;
        }
    }
    catch (Exception ex)
    {
        System.Console.WriteLine(ex.Message);
    }
}