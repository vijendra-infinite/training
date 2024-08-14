using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_LibraryClass;

namespace Travel_ConsoleClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age input.");
                return;
            }

            // Create an instance of TicketBooking class
            TicketBooking booking = new TicketBooking
            {
                Name = name,
                Age = age
            };

            // Calculate and display concession
            string concessionMessage = booking.CalculateConcession();
            Console.WriteLine(concessionMessage);

            // Wait for user input before closing the console
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
    
}
