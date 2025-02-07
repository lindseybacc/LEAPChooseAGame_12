using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Word_Search
{
    public class GameManager
    {
        /* Attributes */
        Player currentPlayer; // Current player object
        string gameLevel; // Game difficulty level

        Word w1 = new Word("Cat", "f5", "f7");
        Word w2 = new Word("Dog", "i1", "g3");
        Word w3 = new Word("Mouse", "a9", "e9");
        Word w4 = new Word("Goat", "j7", "j10");
        Word w5 = new Word("Horse", "c4", "g4");
        List<string> words = new List<string> { "Cat", "Dog", "Mouse", "Goat", "Horse" };
        List<Word> wordList;

        GameState gameState; // Current state of the game


        public List<string> playerGuesses = new List<string>();

        /* Methods */
        // Method to start the game
        public void startGame()
        {
            
            displayScreen();
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
        public bool IsValidCoordinate(string coordinate)
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
                    Console.Clear();
                    startGame();
                }
                else if (difficulty.ToLower() == "m")
                {
                    gameLevel = "M";
                    Console.Clear();
                    startGame();
                }
                else if (difficulty.ToLower() == "h")
                {
                    gameLevel = "H";
                    Console.Clear();
                    startGame();
                }
            }
        }

        // Method to display the score
        public void displayScreen()
        
        {
            wordList = new List<Word> { w1, w2, w3, w4, w5 };
            gameState = GameState.GameStart;
            // display the grid here
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to the Word Search Game!");
            Console.WriteLine();
            Console.WriteLine("Player: " + currentPlayer.playerName);
            Console.WriteLine("Words left to find: " + currentPlayer.getWordsLeft());
            Console.WriteLine();
            Console.WriteLine("Here are the words: ");
            Console.WriteLine();
            for (int i = 0; i < wordList.Count; i++)
            {
                
                Console.WriteLine(wordList[i].getWord());
            }
            getUserInput();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("type Q to quit:");
            var data = Console.ReadLine();

            if (data.ToLower() == "q")
            {
                // call the gameoverscreen method here 
                gameState = GameState.GameOver;
            }
        }

        /* Method: IsValidCoordinate to verify the coordinate format in getUserInput() Method */
        private bool IsValidCoordinate(string coordinate)
        {
            // Check if the coordinate is exactly two characters long
            if (coordinate.Length == 2 && char.IsLetter(coordinate[0]) && char.IsDigit(coordinate[1]))
            {
                return true;
            }
            return false;
        }

        public void gameOverScreen()
        {
            gameState = GameState.GameOver;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ____                         ___                 ");
            Console.WriteLine(" / ___| __ _ _ __ ___   ___   / _ \\__   _____ _ __ ");
            Console.WriteLine("| |  _ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__|");
            Console.WriteLine("| |_| | (_| | | | | | |  __/ | |_| |\\ V /  __/ |   ");
            Console.WriteLine(" \\____|\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|   ");
            Console.WriteLine();
            Console.WriteLine();
            // reset color back to standard
            Console.ResetColor();

            Console.WriteLine("Thanks for playing! \nFINAL BOARD:");
            //displayGrid();

            // Set the text color to Cyan
            

        }
    }
}
