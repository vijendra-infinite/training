using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class exception
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32 (Console.ReadLine());
            ValidateNumber(num);
            Console.WriteLine("Entered number is valid");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Exception caught: {e.Message}");
            Console.ReadLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid integer");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"exception occurred: {e.Message}");
            Console.ReadLine();
        }
    }

    public static void ValidateNumber(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException("given number is negative number");
        }
    }
}