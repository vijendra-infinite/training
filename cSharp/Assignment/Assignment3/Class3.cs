using System;
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
    public class Customer
    {
        public int Customerid;
        public string Name;
        public int Age;
        public long Phone;
<<<<<<< HEAD
        public string City;


        public Customer()
        {
            Console.WriteLine("---Default Constructor withoit Arguments-----");
        }

=======
        public string City;


        public Customer()
        {
            Console.WriteLine("---Default Constructor withoit Arguments-----");
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public Customer(int custid, string name, int age, long phone, string city)
        {
            Customerid = custid;
            Name = name;
            Age = age;
            Phone = phone;
            City = city;
            Console.WriteLine("---Parameterized Constructor with all Arguments---");
<<<<<<< HEAD
        }

=======
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine($"Customer ID: {customer.Customerid}");
            Console.WriteLine($"Customer Name: {customer.Name}");
            Console.WriteLine($"Age of Customer: {customer.Age}");
            Console.WriteLine($"Phone number: {customer.Phone}");
            Console.WriteLine($"City: {customer.City}");
<<<<<<< HEAD
        }

=======
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        ~Customer()
        {
            Console.WriteLine($"Destructor called for customer {Name}");
        }
<<<<<<< HEAD
    }

    class CustomerDetails
    {
        static void Main()
        {

            Customer c1 = new Customer(1, "aadi", 23, 7036775977, "chennai");
            Customer.DisplayCustomer(c1);


            Console.WriteLine("--------------------------------------------------------------");
           
            Console.WriteLine("--------------------------------------------------------------");

=======
    }

    class CustomerDetails
    {
        static void Main()
        {

            Customer c1 = new Customer(1, "aadi", 23, 7036775977, "chennai");
            Customer.DisplayCustomer(c1);


            Console.WriteLine("--------------------------------------------------------------");
           
            Console.WriteLine("--------------------------------------------------------------");

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
            Console.Read();
        }
    }
}