﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Threading.Tasks;

=======
using System.Threading.Tasks;

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
namespace Assignment_3
{
    public class Students
    {
        public int RollNo;
        public string Name;
        public string Class;
        public int Semester;
        public string Branch;
<<<<<<< HEAD
        public int[] marks = new int[5];

=======
        public int[] marks = new int[5];

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public Students(int rollNo, string name, string Classs, int semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            Class = Classs;
            Semester = semester;
            Branch = branch;
<<<<<<< HEAD
        }

=======
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public void GetMarks()
        {
            Console.WriteLine($"Enter marks for Roll No {RollNo}, {Name}");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"Enter marks for Subject {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
<<<<<<< HEAD
        }

=======
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public double DisplayResult()
        {
            double sum = 0;
            foreach (int mark in marks)
            {
                sum += mark;
            }
            return sum / marks.Length;
<<<<<<< HEAD
        }


=======
        }


>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public void DisplayData()
        {
            Console.WriteLine($"Student_Roll_Number = {RollNo}");
            Console.WriteLine($"Student_Name = {Name}");
            Console.WriteLine($"Student_Class = {Class}");
            Console.WriteLine($"Student_Semester = {Semester}");
<<<<<<< HEAD
            Console.WriteLine($"Student_Branch = {Branch}");

=======
            Console.WriteLine($"Student_Branch = {Branch}");

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
            Console.WriteLine("........Displaying student average marks with result..........");
            Console.WriteLine($"Student_Marks");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Subject {i + 1} marks : {marks[i]}");
<<<<<<< HEAD
            }

=======
            }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
            double averageMarks = DisplayResult();
            Console.WriteLine("----------------------");
            Console.WriteLine($"Average Marks: {averageMarks}");
            Console.WriteLine("----------------------");
            if (marks.Any(m => m < 35))
            {
                Console.WriteLine("RESULT: Failed (Marks of one or more subjects are less than 35)");
            }
            else if (averageMarks < 50)
            {
                Console.WriteLine("RESULT: Failed (Average marks are less than 50)");
            }
            else
            {
                Console.WriteLine("RESULT: Passed");
<<<<<<< HEAD
            }


        }


    }


=======
            }


        }


    }


>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
    class StudentDetails
    {
        static void Main()
        {
            Students s = new Students(123, "AADI", "FIFTH", 4, "ECE");
            Console.WriteLine(".......Please Enter Student Marks.........");
            s.GetMarks();
            Console.WriteLine("........Student Results with Info.........");
            s.DisplayData();
            Console.Read();
        }
    }
}