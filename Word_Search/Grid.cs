using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Word_Search
{
    public class Grid
    {
        private char[,] grid { get; }
        public Dictionary<string, int> convert = new Dictionary<string, int>()
        {
            { "A", 0 }, { "B", 1 }, { "C", 2 }, { "D", 3 }, { "E", 4 },
            { "F", 5 }, { "G", 6 }, { "H", 7 }, { "I", 8 }, { "J", 9 },
            { "K", 10 }, { "L", 11 }, { "M", 12 }, { "N", 13 }, { "O", 14 },
            { "P", 15 }, { "Q", 16 }, { "R", 17 }, { "S", 18 }, { "T", 19 },
            { "U", 20 }, { "V", 21 }, { "W", 22 }, { "X", 23 }, { "Y",24 }, { "Z", 25 } };
        public int middle = (Console.WindowWidth / 2) - 34;
     
        public int[,] foundMatrix = new int[10, 10];
        public String[] lines = new string[32];
        public int pos = 0;

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
            if (pos < lines.Length)
            {
                lines[pos] += "|";
                for (int i = 0; i < 74; i++)
                {
                    lines[pos] += "-";
                }
                lines[pos] += "|";
                pos++;
            }
        }

        public void getToMiddle(bool num_line)
        {
            for (int i = 0; i < middle - 2; i++)
            {
               
                if(pos < lines.Length)
                {
                    lines[pos] += " ";
                }
               
            }
        }

        public void displayVerticalLine()
        {
            if (pos < lines.Length)
            {
                getToMiddle(false);
                lines[pos] += "|";
                for (int k = 0; k < 70; k++)
                {
                    lines[pos] += " ";
                }
                lines[pos] += "    |";
                pos++;
            }
        }

        public void displayLetters(int row)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (j == grid.GetLength(1) - 1)
                {
                    lines[pos] += grid[row, j];
                    lines[pos] += ' ';
                    lines[pos] += ' ';

                    lines[pos] += ' ';
                }
                else
                {
                    lines[pos] += grid[row, j] + "      ";
                }
            }
        }
        public void initlizeGrid()
        {
            int num = 1;
            getToMiddle(false);
            displayHorizonalLine();

            displayVerticalLine();
           
            for (int i = 0; i < 10; i++)
            {
                getToMiddle(true);
                lines[pos] += "|";
                addWhiteSpace(5);
                displayLetters(i);
                lines[pos] += "  | ";
                //Console.ForegroundColor = ConsoleColor.Yellow;
                lines[pos] += num;
               // Console.ForegroundColor = ConsoleColor.DarkGray;
                num += 1;
                //lines[pos] += "|";
                pos++;
                

                displayVerticalLine();
                if (i < 9)
                {
                    displayVerticalLine();
                }
            }
            getToMiddle(false);
            displayHorizonalLine();
            displayVerticalLine();

        }
        public void displayGrid()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                A      B      C      D      E      F      G      H      I      J");
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '|' || lines[i][j] == '-')
                    {
                        if (j != 0 || i != 0 || j != lines[i].Length - 1 || i != lines.Length - 1)
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(lines[i][j]);
                        }
                    }
                    else if(lines[i][j] == '1' || lines[i][j] == '2' || lines[i][j] == '3' || lines[i][j] == '4' || lines[i][j] == '5' || lines[i][j] == '6' || lines[i][j] == '7' || lines[i][j] == '8' || lines[i][j] == '9' || lines[i][j] == '0')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(lines[i][j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(lines[i][j]);
                    }
                }
                Console.WriteLine();
            }
        }

       public void addWhiteSpace(int num)
        {
            for (int i = 0; i < num; i++)
            {
                lines[pos] += ' ';
            }
        }
        
       public bool isHorizontal((int, int) start, (int, int) end)
        {
            if (start.Item1 == end.Item1)
            {
                return true;
            }
            return false;
        }
        (int, int) startingLeftCorner((int, int) start)
        {
            int r = 0;
            int c = 0;

            if (start.Item1 == 0)
            {
                r = 1;
            }
            else
            {
                int num = 0;
                num = (start.Item1 * 3) + 1;
                r = num;
            }


            if (start.Item2 == 0)
            {
                c = 4;
            }
            else
            {
                int num = 0;
                num = (start.Item2 * 7) + 5;
                c = num;
            }
            return (r, c);
        }

public int calcVertical((int, int) start, (int, int) end)
{
    return ((end.Item1 - start.Item1) * 2) + 5;
}
public int calcHorizontal((int, int) start, (int, int) end)
{
    if (start.Item2 == 0)
    {
        return ((end.Item2 - start.Item2) * 6) + 1;
    }
    else
    {
        return (((end.Item2 - start.Item2) + 1) * 6) + 3;
    }
}
public void circle((int, int) start, (int, int) end)
{
    bool isHoriz = isHorizontal(start, end);
    (int, int) star_point = startingLeftCorner(start);

    if (isHoriz)
    {
        int last_c = 0;
        for (int i = 0; i < 3; i++)
        {
            char[] temp = lines[star_point.Item1 + i].ToCharArray();
            temp[24 + star_point.Item2] = '|';
            string newString = new string(temp);
            lines[star_point.Item1 + i] = newString;
            last_c = star_point.Item1 + i;
        }

        int h = calcHorizontal(start, end) - 1;
                Console.WriteLine(h);
        int new_lastc = last_c;
        for (int i = 0; i < h; i++)
        {

            char[] temp = lines[star_point.Item1 + 2].ToCharArray();
            temp[star_point.Item2 + 1 + 24 + i] = '-';
            string newString = new string(temp);
            lines[star_point.Item1 + 2] = newString;
            last_c = 24 + i + new_lastc + 1;
        }

        for (int i = 3; i > 0; i--)
        {
            char[] temp = lines[star_point.Item1 + i - 1].ToCharArray();
            temp[star_point.Item2 + 1 + 24 + h] = '|';
            string newString = new string(temp);
            lines[star_point.Item1 + i - 1] = newString;
            last_c--;
        }
        for (int i = 0; i < h; i++)
        {
            char[] temp = lines[star_point.Item1].ToCharArray();
            temp[star_point.Item2 + 1 + 24 + i] = '-';
            string newString = new string(temp);
            lines[star_point.Item1] = newString;
        }
    }
    else
    {
        int v = calcVertical(start, end);

        for (int i = 0; i < v + 1; i++)
        {
            char[] temp = lines[star_point.Item1 + i].ToCharArray();
            temp[24 + star_point.Item2] = '|';
            string newString = new string(temp);
            lines[star_point.Item1 + i] = newString;
        }

        for (int i = 0; i < 5; i++)
        {
            char[] temp = lines[star_point.Item1 + v].ToCharArray();
            temp[star_point.Item2 + 1 + 24 + i] = '-';
            string newString = new string(temp);
            lines[star_point.Item1 + v] = newString;
        }
        for (int i = v; i >= 0; i--)
        {
            char[] temp = lines[star_point.Item1 + i].ToCharArray();
            temp[star_point.Item2 + 1 + 24 + 5] = '|';
            string newString = new string(temp);
            lines[star_point.Item1 + i] = newString;
        }
        for (int i = 0; i < 5; i++)
        {
            char[] temp = lines[star_point.Item1].ToCharArray();
            temp[star_point.Item2 + 1 + 24 + i] = '-';
            string newString = new string(temp);
            lines[star_point.Item1] = newString;
        }
    }
}
public (int,int)[] calculatePositions(Word answer)
        {
            (int, int)[] positions = new (int, int)[answer.getLength()];
            string startPoint = answer.getStartPoint();
            string endPoint = answer.getEndPoint();

            int startR = convert[startPoint[0].ToString().ToUpper()];
            int endR = convert[endPoint[0].ToString().ToUpper()];
            String sc = startPoint[1].ToString();
            String ec = endPoint[1].ToString();
            if (startPoint.Length == 3)
            {
                 sc = "10";
            }
            if (endPoint.Length == 3)
            {
                 ec = "10";
            }

            int startC = int.Parse(sc) -1;
            int endC = int.Parse(ec) -1;

            int[] row = calc(startR, endR, answer.getLength());
            int[] col = calc(startC, endC, answer.getLength());

            positions = storeInTuple(row, col, answer.getLength());
            return positions;

        }
        public (int,int)[] storeInTuple(int[] row, int[] col, int length)
        {
            (int, int)[] pos = new (int, int)[length];
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = (col[i], row[i]);
            }
            return pos;
        }
        public int[] calc(int start, int end, int length)
        {
            int[] positions = new int[length];
            int pos = 0;
            if (start < end)
            {
                
                for (int i = start; i <= end; i++)
                {
                    positions[pos] = i;
                    pos += 1;
                }
            }
            else if (end < start)
            {
                for (int i = end; i >= start; i--)
                {
                    positions[pos] = i;
                    pos += 1;
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    positions[pos] = start;
                    pos += 1;
                }
            }
            return positions;
        }
    }
}
