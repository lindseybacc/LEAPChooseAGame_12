using System;   

namespace Word_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            char[,] grid = {{'L', 'N', 'A', 'U', 'Y', 'K', 'V', 'S', 'D', 'I' },
                            {'L', 'X', 'W', 'L', 'V', 'Q', 'P', 'O', 'O', 'V' },
                             {'N', 'K', 'X', 'E', 'S', 'G', 'G', 'T', 'G', 'Q' },
                            {'F', 'I', 'H', 'O', 'R', 'S', 'E', 'R', 'F', 'S' },
                            {'B', 'K', 'Q', 'H', 'C', 'C', 'Z', 'K', 'T', 'V' },
                            {'T', 'J', 'T', 'J', 'X', 'A', 'N', 'G', 'V', 'S' },
                            {'R', 'Z', 'A', 'A', 'A', 'T', 'Q', 'O', 'D', 'G' },
                            {'H', 'Q', 'Q', 'M', 'R', 'Z', 'Y', 'Y', 'U', 'O' },
                            {'x', 'M', 'O', 'U', 'S', 'E', 'C', 'E', 'Y', 'A' },
                            {'A', 'R', 'H', 'D', 'D', 'Y', 'F', 'Y', 'A', 'T' }};

            Grid my_grid = new Grid(grid);
            my_grid.initlizeGrid();
            Word my_word = new Word("cat", "F5", "F7");
            Word my_word2 = new Word("dog", "I1", "I3");
            Word my_word3 = new Word("mouse", "B9", "F9");
            Word my_word4 = new Word("horse", "C4", "G4");
            Word my_word5 = new Word("goat", "J7", "J10");
            (int, int)[] position = my_grid.calculatePositions(my_word);
            my_grid.circle(position[0], position[position.Length-1]);
            my_grid.displayGrid();

            position = my_grid.calculatePositions(my_word2);

            my_grid.circle(position[0], position[position.Length-1]);
            my_grid.displayGrid();

            position = my_grid.calculatePositions(my_word3);
            Console.WriteLine(position[1]);
            
            my_grid.circle(position[0], position[position.Length-1]);
            my_grid.displayGrid();

            position = my_grid.calculatePositions(my_word4);
            my_grid.circle(position[0], position[position.Length-1]);
            my_grid.displayGrid();

            position = my_grid.calculatePositions(my_word5);
            my_grid.circle(position[0], position[position.Length-1]);
            my_grid.displayGrid();
            Console.WriteLine("Hello World!");*/
            GameManager game = new GameManager();
            game.welcomeScreen();
        }
    }
}