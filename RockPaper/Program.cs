using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock!");
        Console.WriteLine("Choose the version you want to play: (1) Original or (2) Extended");
        int gameVersion = int.Parse(Console.ReadLine());

        string lastUserChoice = null;

        while (true)
        {
            string userChoice;
            string computerChoice;

            if (gameVersion == 1)
            {
                Console.WriteLine("Choose your move: Rock, Paper, Scissors");
                userChoice = Console.ReadLine().ToLower();
                computerChoice = GetComputerChoice(gameVersion);
            }
            else if (gameVersion == 2)
            {
                Console.WriteLine("Choose your move: Rock, Paper, Scissors, Lizard, Spock");
                userChoice = Console.ReadLine().ToLower();
                if (userChoice != "rock" && userChoice != "paper" && userChoice != "scissors" && userChoice != "lizard" && userChoice != "spock")
                {
                    Console.WriteLine("Invalid choice. Please choose from the available options.");
                    continue;
                }
                computerChoice = GetComputerChoice(gameVersion, lastUserChoice);
            }
            else
            {
                Console.WriteLine("Invalid version choice. Please choose (1) Original or (2) Extended.");
                continue;
            }

            Console.WriteLine($"Computer chose: {computerChoice}");
            Console.WriteLine($"You chose: {userChoice}");

            string result;
            if (gameVersion == 1)
            {
                result = DetermineWinner(userChoice, computerChoice);
            }
            else
            {
                result = DetermineExtendedWinner(userChoice, computerChoice);
            }

            Console.WriteLine(result);

            lastUserChoice = userChoice; // Store user's choice for the next round

            Console.WriteLine("Do you want to play again? (yes/no)");
            if (Console.ReadLine().ToLower() != "yes")
            {
                break;
            }
        }
    }

    static string GetComputerChoice(int gameVersion)
    {
        List<string> choices = new List<string>();
        if (gameVersion == 1)
        {
            choices = new List<string> { "rock", "paper", "scissors" };
        }
        else
        {
            choices = new List<string> { "rock", "paper", "scissors", "lizard", "spock" };
        }

        Random random = new Random();
        int index = random.Next(choices.Count);
        return choices[index];
    }

    static string GetComputerChoice(int gameVersion, string lastUserChoice)
    {
        if (lastUserChoice != null)
        {
            return lastUserChoice;
        }

        return GetComputerChoice(gameVersion);
    }

    static string DetermineWinner(string userChoice, string computerChoice)
    {
        // Original Rock, Paper, Scissors logic
        if (userChoice == computerChoice)
        {
            return "It's a tie!";
        }
        else if (
            (userChoice == "rock" && computerChoice == "scissors") ||
            (userChoice == "paper" && computerChoice == "rock") ||
            (userChoice == "scissors" && computerChoice == "paper"))
        {
            return "You win!";
        }
        else
        {
            return "Computer wins!";
        }
    }

    static string DetermineExtendedWinner(string userChoice, string computerChoice)
    {
        // Extended Rock, Paper, Scissors, Lizard, Spock logic
        if (userChoice == computerChoice)
        {
            return "It's a tie!";
        }
        else if (
            (userChoice == "rock" && (computerChoice == "scissors" || computerChoice == "lizard")) ||
            (userChoice == "paper" && (computerChoice == "rock" || computerChoice == "spock")) ||
            (userChoice == "scissors" && (computerChoice == "paper" || computerChoice == "lizard")) ||
            (userChoice == "lizard" && (computerChoice == "spock" || computerChoice == "paper")) ||
            (userChoice == "spock" && (computerChoice == "scissors" || computerChoice == "rock")))
        {
            return "You win!";
        }
        else
        {
            return "Computer wins!";
        }
    }
}