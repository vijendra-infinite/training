using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Doctor
    {
        public string regnNo;
        public string name;
        public decimal feesCharged;
        public Doctor(string regnNo, string name, decimal feesCharged)
        {
            this.regnNo = regnNo;
            this.name = name;
            this.feesCharged = feesCharged;
        }
        public string RegnNo
        {
            get { return regnNo; }
            set { regnNo = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal FeesCharged
        {
            get { return feesCharged; }
            set { feesCharged = value; }
        }
        public void Display()
        {
            Console.WriteLine($"Registration Number: {regnNo}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Fees Charged: {feesCharged}");
        }

        public static void Main()
        {
            Doctor doctor1 = new Doctor("A122", "Dr.Bhabha", 1000);
            doctor1.Display();
            doctor1.Name = "Dr.omshankar";
            doctor1.FeesCharged = 2000;
            doctor1.Display();
            Console.ReadLine();
        }
    }
}   
