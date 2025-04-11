using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set4_Q1
{
    // Interface for common account operations
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        bool Withdraw(decimal amount);
        decimal GetBalance();
    }

    // Abstract base class
    public abstract class BankAccount : IBankAccount
    {
        protected decimal Balance { get; set; }
        public string AccountNumber { get; }
        public string Owner { get; }

        protected BankAccount(string accountNumber, string owner, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public abstract bool Withdraw(decimal amount);

        public decimal GetBalance() => Balance;

        public abstract void DisplayAccountInfo();
    }

    // Concrete implementation - Checking Account
    public class CheckingAccount : BankAccount
    {
        private const decimal OverdraftFee = 35.00m;

        public CheckingAccount(string accountNumber, string owner, decimal initialBalance)
            : base(accountNumber, owner, initialBalance) 
        {
            Console.WriteLine("\nChecking Account Created:");
            this.DisplayAccountInfo();
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
                return true;
            }

            Console.WriteLine($"Insufficient funds for withdrawal of {amount:C}. Overdraft fee applied.");
            Balance -= OverdraftFee;
            return false;
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Checking Account #{AccountNumber}");
            Console.WriteLine($"Owner: {Owner}");
            Console.WriteLine($"Balance: {Balance:C}\n");
        }
    }

    // Concrete implementation - Savings Account
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; }

        public SavingsAccount(string accountNumber, string owner, decimal initialBalance, decimal interestRate)
            : base(accountNumber, owner, initialBalance)
        {
            InterestRate = interestRate;
            Console.WriteLine("\nSavings Account Created:");
            this.DisplayAccountInfo();
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
                return true;
            }

            Console.WriteLine($"Insufficient funds for withdrawal of {amount:C}");
            return false;
        }

        public void ApplyInterest()
        {
            var interest = Balance * InterestRate;
            Deposit(interest);
            Console.WriteLine($"Applied interest: {interest:C}");
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Savings Account #{AccountNumber}");
            Console.WriteLine($"Owner: {Owner}");
            Console.WriteLine($"Balance: {Balance:C}");
            Console.WriteLine($"Interest Rate: {InterestRate:P}\n");
        }
    }

    public static class BankAccountDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Bank Account Demonstration ---");

            IBankAccount checking = new CheckingAccount("CHK123", "John Doe", 500.00m);
            
            checking.Deposit(200.00m);
            checking.Withdraw(100.00m);
            checking.Withdraw(1000.00m);

            Console.WriteLine("\nFinal Account Details:");
            ((BankAccount)checking).DisplayAccountInfo();

            IBankAccount savings = new SavingsAccount("SAV456", "John Doe", 1000.00m, 0.025m);

            savings.Deposit(500.00m);
            savings.Withdraw(200.00m);
            ((SavingsAccount)savings).ApplyInterest();

            Console.WriteLine("\nFinal Account Details:");
            ((BankAccount)savings).DisplayAccountInfo();
        }
    }
}
