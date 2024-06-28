using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Exception_Handling
    {
        public class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException() : base("Insufficient balance for this withdrawal")
            {
            }

        }

        public class BankAccount
        {
            string accountHolder;
            double balance;

            public BankAccount(string accountHolder, double initialBalance)
            {
                this.accountHolder = accountHolder;
                this.balance = initialBalance;
            }

            public double Balance
            {
                get { return balance; }
            }

            public void Deposit(double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException(" amount deposited must be positive", nameof(amount));
                }

                balance += amount;
                Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}");
            }

            public void Withdraw(double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException(" amount must be positive", nameof(amount));
                }

                if (amount > balance)
                {
                    throw new InsufficientBalanceException();
                }

                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}. New balance: {balance:C}");
            }
        }


        public static void Handling()
        {
            try
            {
                Console.Write("Enter account holder name: ");
                string accountHolder = Console.ReadLine();

                Console.Write("Enter initial balance: ");
                double initialBalance = double.Parse(Console.ReadLine());

                BankAccount account = new BankAccount(accountHolder, initialBalance);

                Console.WriteLine($"Current balance: {account.Balance:C}");

                Console.Write("Enter deposit amount: ");
                double depositAmount = double.Parse(Console.ReadLine());
                account.Deposit(depositAmount);

                Console.Write("Enter withdrawal amount: ");
                double withdrawAmount = double.Parse(Console.ReadLine());
                account.Withdraw(withdrawAmount);

                Console.Write("Enter withdrawal amount ");
                withdrawAmount = double.Parse(Console.ReadLine());
                account.Withdraw(withdrawAmount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }

}
