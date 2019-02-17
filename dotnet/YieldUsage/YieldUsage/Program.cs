using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            foreach (var val in Compute(n))
                Console.WriteLine("Value {0}", val);
            Console.ReadLine();
            
        }

        static IEnumerable<int> Compute(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if(i % 2 == 0)
                  yield  return i * i;
            }
            Console.WriteLine("Compute end.");
        }
    }
}
