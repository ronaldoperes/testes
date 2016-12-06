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

            // exercicio TEMPERATURES do codingame
            int n = 5;// int.Parse(Console.ReadLine()); // the number of temperatures to analyse
            string temps = "42 -5 -2 3 4 55 12 21 -5 24";// Console.ReadLine(); // the n temperatures expressed as integers ranging from -273 to 5526
            string sdc= "42 -5 -2 2 3 4 55 12 21 -5 24";
            Console.Error.WriteLine(temps);
            Console.Error.WriteLine(n);
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            int minimum = sdc
                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .OrderBy(Math.Abs)
                           .ThenByDescending(x => x)
                           .FirstOrDefault();

            var minimum2 = sdc
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .OrderBy(Math.Abs);

            var min3 = minimum2.ThenByDescending(x => x);
                          

            Console.WriteLine(minimum2.FirstOrDefault());

            string[] str;

            if (!string.IsNullOrEmpty(temps))

            {
                str = temps.Split(' ');

                int x = int.Parse(str[0]);

                for (int i = 1; i < str.Length; i++)
                {
                    int y = int.Parse(str[i]);

                    if (Math.Abs(x) > Math.Abs(y))
                        x = y;
                    else if (Math.Abs(x) == Math.Abs(y))
                        if (x < 0)
                            x = y;
                }
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

    }
}