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
    public class Accounts
    {
        public int AccountNo;
        public string CustomerName;
        public string AccountType;
        public char TransactionType;
        public double Amount;
<<<<<<< HEAD
        public double Balance;

=======
        public double Balance;

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public Accounts(int accNum, string cName, string accType, char transacType, double amount, double bal)
        {
            AccountNo = accNum;
            CustomerName = cName;
            AccountType = accType;
            TransactionType = transacType;
            Amount = amount;
            Balance = bal;
<<<<<<< HEAD
        }

=======
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public void ShowData()
        {
            Console.WriteLine($"Account Number: {AccountNo}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Account Type(Savings/Current/Salary): {AccountType}");
            Console.WriteLine($"Transaction Type(D-Deposit;W-Withdrawl): {TransactionType}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Balance: {Balance}");
<<<<<<< HEAD
        }

        public void Credit(int amount)
        {
            Balance += amount;
        }

=======
        }

        public void Credit(int amount)
        {
            Balance += amount;
        }

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        public void Debit(int amount)
        {
            if (Balance > amount)
                Balance -= amount;
            else
                Console.WriteLine("Insufficent Balance to withdraw");
<<<<<<< HEAD
        }


=======
        }


>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
    }
    class AccountDetails
    {
        static void Main()
<<<<<<< HEAD
        {

            Console.WriteLine("Enter Account Number:");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter Account Type:");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter Transaction Type (D for deposit, W for withdrawal):");
            char transactionType = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.WriteLine("Enter Amount:");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Accounts ac = new Accounts(accountNumber, customerName, accountType, transactionType, amount, 10000);

            //Accounts ac = new Accounts(123456, "John Doe", "Savings", 'D', 1000.00, 5000.00);

=======
        {

            Console.WriteLine("Enter Account Number:");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter Account Type:");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter Transaction Type (D for deposit, W for withdrawal):");
            char transactionType = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.WriteLine("Enter Amount:");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Accounts ac = new Accounts(accountNumber, customerName, accountType, transactionType, amount, 10000);

            //Accounts ac = new Accounts(123456, "John Doe", "Savings", 'D', 1000.00, 5000.00);

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
            if (ac.TransactionType == 'D')
                ac.Credit((int)ac.Amount);
            else if (ac.TransactionType == 'W')
                ac.Debit((int)ac.Amount);
            else
<<<<<<< HEAD
                Console.WriteLine("incorrect method");

            ac.ShowData();
            Console.Read();

=======
                Console.WriteLine("incorrect method");

            ac.ShowData();
            Console.Read();

>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
        }
    }
}