using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UTeste
{
    class SimpleParser
    {
        public int ParserAndSum(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            if (!numbers.Contains(","))
            {
                return int.Parse(numbers);
            }
            else
            {
                throw new InvalidOperationException("I can only handle 0 or 1 numbers for now!");
            }
        }
    }

    class SimpleParserTests
    {
        static void ShowProblem(string test, string message)
        {
            string msg = string.Format(@"
            ---{0}---
                    {1}
            ---------------------
            ", test, message);
            Console.WriteLine(msg);
        }


        public static void TestReturnsZeroWhenEmptyString()
        {
            string testName = MethodBase.GetCurrentMethod().Name;
            try
            {
                SimpleParser p = new SimpleParser();
                int result = p.ParserAndSum("57");
                if (result != 0)
                {
                    ShowProblem(testName, "Parse and sum should have returned 0 on an empty string");

                }
            }
            catch (Exception e)
            {
                ShowProblem(testName, e.ToString());
            }
        }
    }


}
