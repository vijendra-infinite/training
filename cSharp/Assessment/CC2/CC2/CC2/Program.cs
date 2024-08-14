using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Undergraduate undergraduate = new Undergraduate();

            Console.WriteLine("Enter undergraduate student details:");
            Console.Write("Name: ");
            undergraduate.Name = Console.ReadLine();
            Console.Write("Student ID: ");
            undergraduate.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Grade: ");
            undergraduate.Grade = Convert.ToDouble(Console.ReadLine());

            bool isPassedUndergrad = undergraduate.IsPassed(undergraduate.Grade);
            Console.WriteLine($"{undergraduate.Name} {(isPassedUndergrad ? "passed" : "failed")}.");

            Graduate graduate = new Graduate();

            Console.WriteLine("\nEnter graduate student details:");
            Console.Write("Name: ");
            graduate.Name = Console.ReadLine();
            Console.Write("Student ID: ");
            graduate.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Grade: ");
            graduate.Grade = Convert.ToDouble(Console.ReadLine());

            bool isPassedGrad = graduate.IsPassed(graduate.Grade);
            Console.WriteLine($"{graduate.Name} {(isPassedGrad ? "passed" : "failed")}.");
            Console.ReadLine();
        }
    }
}