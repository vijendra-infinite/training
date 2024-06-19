using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //triple();
            // weekdays();
            //FindAverage();
            //Marks();
            // Copyarray();
            Stringoperation();
            Console.Read();
        }
        public static void triple()
        {
            Console.WriteLine("enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the second number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 + num2;
            if(num1==num2)
            {
                Console.WriteLine(sum * 3);
            }
            else { Console.WriteLine("The sum of the numbers is " + sum); }
            
        }
        public static void weekdays()
        {
            Console.WriteLine("enter the day of week");
            int day=Convert.ToInt32(Console.ReadLine());
            switch(day)
            {
                case 1:
                        Console.WriteLine("sunday");
                    break;
                case 2:
                    Console.WriteLine("monday");
                    break;
                case 3:
                    Console.WriteLine("tuesday");
                    break;
                case 4:
                    Console.WriteLine("wednesday");
                    break;
                case 5:
                    Console.WriteLine("thursday");
                    break;
                case 6:
                    Console.WriteLine("friday");
                    break;
                case 7:
                    Console.WriteLine("saturday");
                    break;
                default :
                    Console.WriteLine("enter a valid day");
                    break;

            }
        }

        static void FindAverage()
        {
            Console.Write("enter array size : ");
            Console.WriteLine();
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine("enter {0} values ", size);
            for(int i=0;i<size;i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int min = arr[0];
            int max = arr[0];
            int average = 0;
            Array.Sort(arr);
            for(int i=0;i<size;i++)
            {
                average = average + arr[i];
               
            }
            Console.WriteLine($"Average of given value is {average/size}");
            Console.WriteLine($"Min value is {arr[0]} and Max value is {arr[size-1]}");
        }
        static void Marks()
        {

            int size = 10;
            int[] arr = new int[size];
            Console.WriteLine("enter {0} marks ", size);
            for (int i = 0; i < size; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum = sum + arr[i];
             
            }
            Console.WriteLine($"sum of marks is {sum}");
            Console.WriteLine($"Average of given marks is {sum / size}");
            Array.Sort(arr);
            Console.WriteLine($"Min marks is {arr[0]} and Max marks is {arr[9]}");
            Console.WriteLine("marks in ascending order");
            for(int i=0;i<size;i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            Array.Reverse(arr);
            Console.WriteLine("marks in descending order");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
        static void Copyarray()
        {
            Console.WriteLine("enter an array size");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[size];
            Console.WriteLine("enter values of array1");
            for(int i=0;i<size;i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] arr2 = new int[size];
            Console.WriteLine("created array2 and copied values of array1 to array2 displaying array2");
            for(int i=0;i<size;i++)
            {
                arr2[i] = arr1[i];
            }
           for(int i=0;i<size;i++)
            {
                Console.Write($" {arr2[i]} ");
            }

        }
        static void Stringoperation()
        {
            Console.WriteLine("enter a word");
            string str = Console.ReadLine();
            Console.WriteLine($"length of {str} is {str.Length}");
            Console.WriteLine("enter a word");
            string str1 = Console.ReadLine();
            string res = "";
            for(int i=0;i<str1.Length;i++)
            {
                res = str1[i] + res;
            }
            Console.WriteLine($"given word is {str1}  after reversing the word is {res} ");
            Console.WriteLine("enter a first word");
            string str2 = Console.ReadLine();
            Console.WriteLine("enter a second word");
            string str3 = Console.ReadLine();
            if(str2 == str3)
            {
                Console.WriteLine("both strings are same");
            }
            else
            {
               Console.WriteLine( "both strings are different");
            }

        }
    }
}
