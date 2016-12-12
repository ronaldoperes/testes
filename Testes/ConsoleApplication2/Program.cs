using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> asdf = new List<int>();

            asdf.Add(29);
            asdf.Add(22);
            asdf.Add(21);
            asdf.Add(27);

            asdf = asdf.OrderByDescending(i => i).ToList();

            int smallestStrengthDifference = int.MaxValue;

            for (int i = 0; i < asdf.Count; i++)
            {
                if (i == 0)
                {
                    smallestStrengthDifference = asdf[i] - asdf[i + 1];
                }
                else if (asdf[i - 1] - asdf[i] < smallestStrengthDifference)
                {
                    smallestStrengthDifference = asdf[i - 1] - asdf[i];
                }
            }

            Console.WriteLine(smallestStrengthDifference);


            string[] inputs = Console.ReadLine().Split(' ');
            int lightX = 10;//int.Parse(inputs[0]); // the X position of the light of power
            int lightY = 10;//int.Parse(inputs[1]); // the Y position of the light of power
            int initialTX = 0;//int.Parse(inputs[2]); // Thor's starting X position
            int initialTY = 0;//int.Parse(inputs[3]); // Thor's starting Y position

            int tX = initialTX;
            int tY = initialTY;

            string[,] directions = new string[3, 3] {{"NW", "N", "NE"}
                                                , {"W", "", "E"}
                                                , {"SW", "S", "SE"}};


            // game loop
            while (true)
            {
                int remainingTurns = 30;// int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                int xDir = Math.Sign(lightX.CompareTo(tX));

                int yDir = Math.Sign(lightY.CompareTo(tY));

                string travelDir = directions[yDir + 1, xDir + 1];

                Console.WriteLine(travelDir); // A single line providing the move to be made: N NE E SE S SW W or NW

                tX += xDir;
                tY += yDir;
            }

        }
    }

}
