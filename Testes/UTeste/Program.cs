using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTeste
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleParserTests.TestReturnsZeroWhenEmptyString();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

   
}
