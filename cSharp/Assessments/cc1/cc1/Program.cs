using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a C# Sharp program to check the largest number among three given integers");
            Program.program3();
            Console.ReadLine();
            Console.WriteLine("*********************");
            Console.WriteLine("Write a C# Sharp program that prints the multiplication table of a number as input.");
            Program.multiplication();
            Console.ReadLine();
            

            
        }
        public static void program3()
        {
            Console.WriteLine("enter the first integer");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the second integer");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the third integer");
            int num3 = Convert.ToInt32(Console.ReadLine());
            if(num1>num2 && num1>num3 )
            {
                Console.WriteLine(num1);
            }
            else if(num2>num1 && num2>num3)
            {
                Console.WriteLine(num2);
            }
            else
            {
                Console.WriteLine(num3);
            }
        }
        public static void multiplication ()
        {
            Console.WriteLine("enter a number");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <=10; i++)
            {
                
                Console.WriteLine("{0}*{1}={2}",number,i,number*i);
            }
        }
       
               
        
            
        
            
        
    }
}
