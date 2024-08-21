using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CC3
{

    public class Cricket
    {
        private int[] scores;
        private int numberOfMatches;

        public int NumberOfMatches
        {
            get { return numberOfMatches; }
            set { numberOfMatches = value; }
        }

        public void PointsCalculation()
        {
            scores = new int[NumberOfMatches]; 

            for (int i = 0; i < NumberOfMatches; i++)
            {
                Console.Write($"Enter score for match {i + 1}: ");
                int score = Convert.ToInt32(Console.ReadLine());
                scores[i] = score;
            }

            int sum = 0;
            foreach (int score in scores)
            {
                sum += score;
            }

            double average = (double)sum / NumberOfMatches;

            Console.WriteLine($"Sum of scores: {sum}");
            Console.WriteLine($"Average of scores: {average:F2}");
        }
    }
    //[-------------------PROGRAM2---------------]

    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }
        public static Box Add(Box box1, Box box2)
        {
            double sumLength = box1.Length + box2.Length;
            double sumBreadth = box1.Breadth + box2.Breadth;
            return new Box(sumLength, sumBreadth);
        }
        public void Display()
        {
            Console.WriteLine($"Box Dimensions - Length: {Length}, Breadth: {Breadth}");
        }

        public static void Display2()
        {
            Console.WriteLine("Enter dimensions for Box 1:");
            Console.Write("Length: ");
            double length1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nEnter dimensions for Box 2:");
            Console.Write("Length: ");
            double length2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());
            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);
            Box box3 = Box.Add(box1, box2);
            Console.WriteLine("\nBox 1:");
            box1.Display();
            Console.WriteLine("\nBox 2:");
            box2.Display();
            Console.WriteLine("\nBox 3 (Sum of Box 1 and Box 2):");
            box3.Display();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of matches: ");
            int numMatches = Convert.ToInt32(Console.ReadLine());

            Cricket cricket = new Cricket();
            cricket.NumberOfMatches = numMatches;
            cricket.PointsCalculation();

            Console.WriteLine("--------PROGRAM2-------");
            Box.Display2();
            Console.WriteLine("----------------");
            Console.ReadLine();
        }
    }
}

