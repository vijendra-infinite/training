using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class OccuranceCount
    {
        public static void Test()
        {
            string s = Console.ReadLine();
            char c = Console.ReadLine()[0];
            int count = 0;
            foreach (char ch in s)
            {
                if (ch == c)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
