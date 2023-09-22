﻿public static class Dialog
{
    public static void StartDialog()
    {
        string? userSelection;

        do
        {
            //print the first screen
            //this is another comment
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************************");
            Console.WriteLine("* Welcome to the Loropio Fitness App *");
            Console.WriteLine("**************************************");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("********************");
            Console.WriteLine("* Select an action *");
            Console.WriteLine("********************");

            Console.WriteLine("1: Enter new User and Activities");
            Console.WriteLine("2: Load User and Activities");
            Console.WriteLine("3: Retrieve and Update User by Id");
            Console.WriteLine("4: Retrieve and Update Activity by User Id");
            Console.WriteLine("5: Delete User");
            Console.WriteLine("6: Delete Activity by User Id");
            Console.WriteLine("9: Quit application");
            Console.Write("Your selection: ");

            userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    ActivityDialog.EnterNewUserAndActivity();
                    break;
                case "2":
                    ActivityDialog.LoadUserAndActivities();
                    break;
                case "3":
                    ActivityDialog.RetrieveAndUpdateUser();
                    break;
                case "4":
                    ActivityDialog.RetrieveAndUpdateActivity();
                    break;
                case "5":
                    ActivityDialog.DeleteUser();
                    break;
                case "6":
                    ActivityDialog.DeleteActivityForUserId();
                    break;
                case "9": break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
        while (userSelection != "9");

        Console.WriteLine("Thanks for using Loropio Fitness App");
    }
}