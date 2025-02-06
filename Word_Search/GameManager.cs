using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Word_Search
{
    public class GameManager
    {
        /* Attributes */
        // Grid grid (need grid class)
        Player currentPlayer; // Current player object
        string gameLevel; // Game difficulty level
        //List<Word> answerPositions; (Need word class)
        GameState gameState; // Current state of the game
        public List<string> playerGuesses = new List<string>();
        //List<Word> answerPositions; (Need word class)

        /* Methods */
        // Method to start the game
        public void startGame()
        {
        }

        // Method to initialize the grid
        public void initializeGrid()
        {
        }

        // Method to display the grid
        
        public void displayGrid()
        {
        }

        // Method to get user input
        public void getUserInput()
        {
            string input;
            string firstCoordinate;
            string secondCoordinate;
            bool isValidGuess = false; //run loop until entry is valid

            Console.WriteLine("Enter the coordinates for the first letter and last letter of your word guess, with a comma in between. " +
                "\nFormat should have a letter to represent the column, and a number to represent the row. Example: A1, F1. ");

            do
            {
                input = Console.ReadLine();

                // To split the entry by comma and store in array
                string[] parts = input.Split(',');

                // Check there are two parts with comma
                if (parts.Length == 2)
                {
                    firstCoordinate = parts[0].Trim();
                    secondCoordinate = parts[1].Trim();

                    // Validate each part, created a separate method to valid the coordinate
                    if (IsValidCoordinate(firstCoordinate) && IsValidCoordinate(secondCoordinate))
                    {
                        isValidGuess = true;
                        playerGuesses.Add(firstCoordinate); //storing the coordinate string in list for validation
                        playerGuesses.Add(secondCoordinate);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Each coordinate should be in the format LetterNumber (e.g., A1).");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter two coordinates separated by a comma (e.g., A1, F1).");
                }
            } while (!isValidGuess);
        }

        // Method to check if the word is correct
        
        /* Method: IsValidCoordinate to verify the coordiante format in getUserInput() Method */
        private bool IsValidCoordinate(string coordinate)
        {
            // Check if the coordinate is exactly two characters long
            if (coordinate.Length == 2 && char.IsLetter(coordinate[0]) && char.IsDigit(coordinate[1]))
            {
                return true;
            }
            return false;
        }

        public void checkWord()
        {
        }

        // Method to update the score
        public void updateScore()
        {
        }

        // Method to display the welcome screen
        public void welcomeScreen()
        {
            gameState = GameState.MainMenu;
            // Set the text color to Cyan
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ____    __    ____  ______   .______       _______          _______. _______     ___      .______        ______  __    __  ");
            Console.WriteLine("\\   \\  /  \\  /   / /  __  \\  |   _  \\     |       \\        /       ||   ____|   /   \\     |   _  \\      /      ||  |  |  | ");
            Console.WriteLine(" \\   \\/    \\/   / |  |  |  | |  |_)  |    |  .--.  |      |   (----`|  |__     /  ^  \\    |  |_)  |    |  ,----'|  |__|  | ");
            Console.WriteLine("  \\            /  |  |  |  | |      /     |  |  |  |       \\   \\    |   __|   /  /_\\  \\   |      /     |  |     |   __   | ");
            Console.WriteLine("   \\    /\\    /   |  `--'  | |  |\\  \\----.|  '--'  |   .----)   |   |  |____ /  _____  \\  |  |\\  \\----.|  `----.|  |  |  | ");
            Console.WriteLine("    \\__/  \\__/     \\______/  | _| `._____||_______/    |_______/    |_______/__/     \\__\\ | _| `._____| \\______||__|  |__|");
            Console.WriteLine();
            Console.WriteLine();

            // Set the text color to Yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press the s key to begin:");
            var key = Console.ReadLine();
            // Reset the text color to the default color
            //Console.ResetColor();

            if (key.ToLower() == "s".ToLower())
            {
                gameState = GameState.GameSetup;
                Console.WriteLine("Please choose your difficulty level: Type 'E' for Easy, 'M' for Medium, or 'H' for Hard");
                var difficulty = Console.ReadLine();
                Console.WriteLine("Enter your name:");
                var name = Console.ReadLine();
                currentPlayer = new Player(name);
                if (difficulty.ToLower() == "e")
                {
                    gameLevel = "E";
                    startGame();
                }
                else if (difficulty.ToLower() == "m")
                {
                    gameLevel = "M";
                    startGame();
                }
                else if (difficulty.ToLower() == "h")
                {
                    gameLevel = "H";
                    startGame();
                }
            }
        }

        // Method to display the score
        public void displayScreen()
        {
        }
    }
}
