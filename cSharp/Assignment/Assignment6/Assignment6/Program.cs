using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program
    {
        public static void Program1()
        {
            Console.WriteLine("enter the number:");
            Console.ReadLine();
            int[] numbers = { 7, 2, 30 };
            foreach (int number in numbers)
            {
                int square = number * number;
                if (square > 20)
                {
                    Console.WriteLine($"{number} - {square}");
                }
            }
        }

        //--------------------------------------------------------------------

        public static void Program2()
        {
            Console.WriteLine("enter the strings:");
            Console.ReadLine();
            List<string> words = new List<string> { "mum", "amsterdam", "bloom" };
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    char firstChar = char.ToLower(word[0]);
                    bool startsWithA = (firstChar == 'a');
                    char lastChar = char.ToLower(word[word.Length - 1]);
                    bool endsWithM = (lastChar == 'm');

                    if (startsWithA && endsWithM)
                    {
                        Console.WriteLine(word);
                    }
                }
            }

        }

        public static void Main()
        {
            Console.WriteLine("program1");
            Program1();

            Console.WriteLine("Program2");
            Program2();

            Console.WriteLine("Program3");
            Employee.Program3();


            Console.ReadLine();



                
        }
    }

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public decimal EmpSalary { get; set; }

        public static void Program3()
        {
            Employee[] employees = new Employee[]
            {
            new Employee { EmpId = 1, EmpName = "rithu", EmpCity = "Bangalore", EmpSalary = 55000 },
            new Employee { EmpId = 2, EmpName = "riya", EmpCity = "Mumbai", EmpSalary = 58000 },
            new Employee { EmpId = 3, EmpName = "sweety", EmpCity = "Delhi", EmpSalary = 43000 },
            new Employee { EmpId = 4, EmpName = "chitty", EmpCity = "Bangalore", EmpSalary = 48000 },
            new Employee { EmpId = 5, EmpName = "priya", EmpCity = "Chennai", EmpSalary = 63000 }
            };

            Console.WriteLine("All Employees:");
            DisplayEmployees(employees);

            Console.WriteLine("\nEmployees with Salary > 45000:");
            DisplayEmployeesWithSalaryAbove(employees, 45000);

            Console.WriteLine("\nEmployees from Bangalore:");
            DisplayEmployeesFromCity(employees, "Bangalore");

            Console.WriteLine("\nEmployees sorted by Name (Ascending):");
            Array.Sort(employees, (x, y) => string.Compare(x.EmpName, y.EmpName));
            DisplayEmployees(employees);
        }
        static void DisplayEmployees(Employee[] employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                Console.ReadLine();
            }
        }
        static void DisplayEmployeesWithSalaryAbove(Employee[] employees, decimal salaryThreshold)
        {
            foreach (var emp in employees)
            {
                if (emp.EmpSalary > salaryThreshold)
                {
                    Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                    Console.ReadLine();
                }
            }
        }


        static void DisplayEmployeesFromCity(Employee[] employees, string city)
        {
            foreach (var emp in employees)
            {
                if (emp.EmpCity.Equals(city, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                    Console.ReadLine();
                }
            }
        }
    }
}
    

    

