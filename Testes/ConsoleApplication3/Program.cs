using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    SOLUÇÃO DO CODING GAME 'THERE IS NO SPOON EPISODE 1'
    https://www.codingame.com/ide/puzzle/there-is-no-spoon-episode-1
     
     */

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 3;//int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = 3;// int.Parse(Console.ReadLine()); // the number of cells on the Y axis

            string[,] matrix = new string[height, width];

            //Console.Error.WriteLine(width);
            //Console.Error.WriteLine(height);

            string[] line = new string[height];
            line[0] = "000";
            line[1] = ".0.";
            line[2] = ".0.";
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = (line[i][j]).ToString();
                }
            }
            

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i, j] == "0")
                        Console.WriteLine(chkPosition(i, j, width, height, matrix[i, j], matrix));
                }
            }


        }

        private static string chkPosition(int i, int j, int width, int height, string v, string[,] matrix)
        {
            string str = "" + j + " " + i + " ",
                X= "", Y = "";

            // linha
            for (int d = j+1; d < width; d++)
            {
                if (matrix[i,d] == "0")
                {
                    X = "" + d + " " + i + " ";
                    break;
                }
                else
                {
                    X = "-1 -1 ";
                }
            }

            //coluna
            for (int d = i+1; d < height; d++)
            {
                if (matrix[d, j] == "0")
                {
                    Y = " " + j + " " + d;
                    break;
                }
                else
                {
                    Y = "-1 -1";
                }
            }

            if (X == "")
                X = "-1 -1";

            if (Y == "")
                Y = "-1 -1";

            str = str + X + Y;
            return str;
        }

    }
}
