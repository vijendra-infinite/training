using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Uppercase
    {
        public static void Display(string firstName, string lastName)
        {
            Console.WriteLine(firstName.ToUpper());
            Console.WriteLine(lastName.ToUpper());
        }

        public static void Main()
        {
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your last name:");
            string lastName = Console.ReadLine();

            Uppercase.Display(firstName, lastName);

            Console.WriteLine("----------CHARACTER OCCURANCE----------");
            OccuranceCount.Test();

            Console.WriteLine("--------EXCEPTION HANDLING--------------");
            Exception_Handling.Handling();

            Console.WriteLine("=======SCHOLARSHIP MANAGEMENT=======");
            Scholarship s = new Scholarship();
            Console.WriteLine("Scholarship Amount");
            Console.WriteLine(s.stud(89, 60000));
            Console.Read();

        }

    }
    class Scholarship

    {
        public double stud(int marks, double fees)
        {
            double scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = 0.3 * fees;
            }
            else if (marks > 90)
            {
                scholarshipAmount = 0.5 * fees;
            }
            return scholarshipAmount;
        }
    }
}
