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
        Console.WriteLine("Welcome to Loropio Fitness App");
        Console.WriteLine("1. Create a new user account");
        Console.WriteLine("2. Logon");
        Console.WriteLine("3. Quit");
        Console.WriteLine("Your selection: ");

        bool validInput = false;
        while (!validInput)
        {
            string? userSelection = Console.ReadLine();

            switch (userSelection)
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
        Console.WriteLine("Enter your details to register!");
        Console.WriteLine("Enter your username: ");
        string? userNameInput = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string? passwordInput = Console.ReadLine();

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
        Console.WriteLine("Enter your credentials to Logon");
        Console.WriteLine("Enter your username: ");
        string? userNameInput = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string? passwordInput = Console.ReadLine();

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
        // Task 1: Add the Dialog to Enter a new Sport Activity
        // Use the existing ActivityDialog class to enter the Sport Activity
        Console.WriteLine("1. Register a new activity");
        Console.WriteLine("99. Logout");
        Console.Write("Your selection: ");
        string? userSelection = Console.ReadLine();

        ActivityDialog activityDialog = new();
        activityDialog.SetUserId(user.Id);

        switch (userSelection)
        {
            case "1":
                activityDialog.RegisterNewActivity();
                break;
            case "99":
                activityDialog.LogOut();
                break;
            default:
                Console.WriteLine("Invalid selection, please try again");
                break;
        }
    }
}