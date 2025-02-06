using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Search
{
    public class GameManager
    {
        /* Attributes */
        // Grid grid (need grid class)
        public List<string> playerGuesses = new List<string>();
        Player currentPlayer;
        //List<Word> answerPositions; (Need word class)


        /* Methods */
        public void startGame()
        {
        }

        public void initializeGrid()
        {
        }

        
        public void displayGrid()
        {
        }

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

        public void updateScore()
        {
        }

        public void welcomeScreen()
        {
        }

        public void displayScreen()
        {
        }   

    }
}
