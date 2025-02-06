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
        List<String> playerGuesses; // List to store player's guesses
        Player currentPlayer; // Current player object
        string gameLevel; // Game difficulty level
                          //List<Word> answerPositions; (Need word class)
        GameState gameState; // Current state of the game

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
        }

        // Method to check if the word is correct
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
        public void displayScore()
        {
        }
    }
}
