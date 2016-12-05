using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

            string[,] matrix = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine(); // width characters, each either 0 or .
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = line[j].ToString();
                }

            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // Three coordinates: a node, its right neighbor, its bottom neighbor
            //Console.WriteLine("0 0 1 0 0 1");
        }
    }
}
