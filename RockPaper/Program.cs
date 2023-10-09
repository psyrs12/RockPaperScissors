using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Rock, Paper, Scissors!");
        while (true)
        {
            Console.WriteLine("Choose your move: Rock, Paper, Scissors");
            string userChoice = Console.ReadLine().ToLower(); // Convert user input to lowercase
            string computerChoice = GetComputerChoice();

            Console.WriteLine($"Computer chose: {computerChoice}");
            Console.WriteLine($"You chose: {userChoice}");

            string result = DetermineWinner(userChoice, computerChoice);
            Console.WriteLine(result);

            Console.WriteLine("Do you want to play again? (yes/no)");
            if (Console.ReadLine().ToLower() != "yes")
            {
                break;
            }
        }
    }

    static string GetComputerChoice()
    {
        List<string> choices = new List<string> { "Rock", "Paper", "Scissors" };
        Random random = new Random();
        int index = random.Next(choices.Count);
        return choices[index];
    }

    static string DetermineWinner(string userChoice, string computerChoice)
    {
        if (userChoice == computerChoice.ToLower()) // Convert computer choice to lowercase before comparison
        {
            return "It's a tie!";
        }
        else if (
            (userChoice == "rock" && computerChoice == "Scissors") ||
            (userChoice == "paper" && computerChoice == "Rock") ||
            (userChoice == "scissors" && computerChoice == "Paper"))
        {
            return "You win!";
        }
        else
        {
            return "Computer wins!";
        }
    }
}