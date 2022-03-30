using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class program
    {
        static void Main(String[] args)
        {
            Calculator calc = new Calculator();
            calc.x = 10;
            calc.y = 20;
            int result = calc.Add();
            Console.WriteLine(result);
        }
    }
}
