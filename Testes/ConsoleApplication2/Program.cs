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
            string str = "0 0 0 1 0- 0 0 .";
            int n = str.Length;

            string s = "";

            if (str.Contains("-"))
            {
                var res = (str.Replace("-","").Replace(".","").Replace(" ","")).OrderBy(x => { return x; }).ToList();
                s = "-";
                for (int i = 0; i < res.Count(); i++)
                {
                    if (i == 1)
                        s += "." + res[i].ToString();
                    else
                    {
                        s+= res[i].ToString();
                    }

                }
            }
            else
            {
                var res = (str.Replace("-", "").Replace(".", "").Replace(" ", "")).OrderByDescending(x => { return x; }).ToList();
                for (int i = 0; i < res.Count(); i++)
                {
                    if (i == res.Count() - 1)
                    {
                        s += "." + res[i].ToString();
                    }
                    else
                    {
                        s += res[i].ToString();
                    }
                }
            }

            int.Parse(s);
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
