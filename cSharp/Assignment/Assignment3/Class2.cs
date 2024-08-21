using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Threading.Tasks;

namespace Assignment_3
{

=======
using System.Threading.Tasks;

namespace Assignment_3
{

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
    public class SaleDetails
    {
        public int SalesNo;
        public int ProductNo;
        public decimal Price;
        public DateTime DateOfSale;
        public int Qty;
<<<<<<< HEAD
        public decimal TotalAmount;

=======
        public decimal TotalAmount;

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public SaleDetails(int salesNo, int productNo, decimal price, DateTime dateOfSale, int qty)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            DateOfSale = dateOfSale;
            Qty = qty;
            Sales();
<<<<<<< HEAD
        }

        private void Sales()
        {
            TotalAmount = Price * Qty;
        }

=======
        }

        private void Sales()
        {
            TotalAmount = Price * Qty;
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public void ShowData()
        {
            Console.WriteLine($"Sales Number: {SalesNo}");
            Console.WriteLine($"Product Number: {ProductNo}");
            Console.WriteLine($"Price per unit: {Price:C}");
            Console.WriteLine($"Date of Sale: {DateOfSale.ToShortDateString()}");
            Console.WriteLine($"Quantity sold: {Qty}");
            Console.WriteLine($"Total Amount: {TotalAmount:C}");
        }
        public static void Main()
        {
<<<<<<< HEAD
            SaleDetails sd1 = new SaleDetails(1, 101, 25.5m, DateTime.Today, 5);

            SaleDetails sd2 = new SaleDetails(2, 156, 45m, DateTime.Today, 7);
            Console.WriteLine("-------------TODAY SALE DETAILS------");
            sd1.ShowData();

            Console.WriteLine("-----------------------------------");
            sd2.ShowData();


            Console.Read();
        }
    }




=======
            SaleDetails sd1 = new SaleDetails(1, 101, 25.5m, DateTime.Today, 5);

            SaleDetails sd2 = new SaleDetails(2, 156, 45m, DateTime.Today, 7);
            Console.WriteLine("-------------TODAY SALE DETAILS------");
            sd1.ShowData();

            Console.WriteLine("-----------------------------------");
            sd2.ShowData();


            Console.Read();
        }
    }




>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
}