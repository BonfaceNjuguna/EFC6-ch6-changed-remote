using FitnessApp.Data.Repository;
using FitnessApp.Domain.Contracts;
using FitnessApp.Domain.Entitities;

namespace FitnessApp.UI.Dialog;

public class UserDialog
{
    private IUserRepository userRepository;
    private User user;

    public UserDialog()
    {
        userRepository = new UserRepository();
        // in the constructor of the UserDialog we create a UserRepository and a User
        // the repository is passed to the User in his constructor so that a User Domain Object has access to his repository
        user = new User(userRepository);
    }

    public void StartLogonDialog()
    {
        // Task 1: Create the first Dialog with the options to Create a new User Account, Logon to the Application or Quit
        Console.WriteLine("Welcome to Loropio Fitness App");
        Console.WriteLine("1. Create a new user account");
        Console.WriteLine("2. Logon");
        Console.WriteLine("3. Quit");
        Console.WriteLine("Your selection: ");

        bool validInput = false;
        while (!validInput)
        {
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ShowRegisterNewUserDialog();
                    validInput = true;
                    break;
                case "2":
                    ShowLogonDialog();
                    validInput = true;
                    break;
                case "3":
                    validInput = true;
                    Console.WriteLine("Thank you for using Loropio Fitness App");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1, 2, or 3):");
                    break;
            }
        }
    }

    private void ShowRegisterNewUserDialog()
    {
        // Task 2:Create a Dialog for User to Register with his UserName and his Password
        Console.WriteLine("Enter your details to register!");
        Console.WriteLine("Enter your username: ");
        string? userNameInput = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string? passwordInput = Console.ReadLine();

        // Task 3: Uncomment the lines below and make the work. Use the already implemented Register method for the User

        if (!string.IsNullOrEmpty(userNameInput) && !string.IsNullOrEmpty(passwordInput))
        {
            user.Register(userNameInput, passwordInput);
        }
        else
        {
            Console.WriteLine("You did not enter valid credentials !");
        }
    }

    private void ShowLogonDialog()
    {
        // Task 4: Create the Dialog to Logon with Username and Password
        Console.WriteLine("Enter your credentials to Logon");
        Console.WriteLine("Enter your username: ");
        string? userNameInput = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string? passwordInput = Console.ReadLine();

        // uncomment the lines below and make the work

        if (!string.IsNullOrEmpty(userNameInput) && !string.IsNullOrEmpty(passwordInput))
        {
             var credentialsAreValid = user.GetCredentialsAreValid(userNameInput, passwordInput);

            if (credentialsAreValid)
            {
                Console.WriteLine($"Welcome {user.UserName}, you have logged on successfully !");
                ShowActivityDialog();
            }
            else
            {
                Console.WriteLine("You did not enter valid credentials !");
                StartLogonDialog();
            }
        }
        else
        {
            Console.WriteLine("You did not provide your User Name username or Password !");
        }
    }

    private void ShowActivityDialog()
    {
        // Task 9 Add the Dialog to Enter a new Sport Activity
        // Use the existing ActivityDialog class to enter the Sport Activity
    }
}