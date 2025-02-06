using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Word_Search
{
    public class Grid
    {
        private char[,] grid { get; }
        public int middle = (Console.WindowWidth / 2) - 46 / 2;

        public Grid(char[,] letters)
        {
            grid = letters;
        }
        public char[,] getGrid()
        {
            return grid;
        }
        public void displayHorizonalLine()
        {
            Console.Write("|");
            for (int i = 0; i < 45; i++)
            {
                Console.Write("-");
            }
            Console.Write("|");
        }
        public void getToMiddle()
        {
            for (int i = 0; i < middle - 2; i++)
            {
                Console.Write(" ");
            }
        }
       
        public void displayVerticalLine()
        {
            getToMiddle();

            Console.Write("|");
            for (int k = 0; k < 45; k++)
            {
                Console.Write(" ");
            }
            Console.Write("|");

        }
        public void displayLetters(int row)
        {
            Console.Write("|  ");
            for (int j = 0; j < grid.GetLength(1) - 1; j++)
            {
                if (j == grid.GetLength(1) - 2)
                {
                    Console.Write(grid[row, j] + " ");
                }
                else { 
                    Console.Write(grid[row, j] + "    ");
                }
            }

        }
        public void displayGrid()
        {
            getToMiddle();
            displayHorizonalLine();
            Console.WriteLine();
            displayVerticalLine();
            Console.WriteLine();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                getToMiddle();
                displayLetters(i);
                Console.Write(" |");
                Console.WriteLine();

               displayVerticalLine();
                Console.WriteLine();
            }
            getToMiddle();
            displayHorizonalLine();
        }
    }      
}
