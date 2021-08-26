using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOOP
{
    public interface IDeposit
    {
        void Deposit(decimal amount);
    }

    public interface IWithdraw
    {
        void Deposit(decimal amount);
    }

    public abstract class Account : IWithdraw
    {
        protected decimal balance;

        public Customer Customer { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
        }

        public Account(Customer customer)
        {
            this.balance = 0;
            this.InterestRate = this.InterestRate / 100M;
            this.Customer = customer;
        }

        public Account(Customer customer, decimal balance) : this(customer)
        {
            this.balance = balance;
        }

        public Account(Customer customer, decimal balance, decimal interestRate) : this(customer, balance)
        {
            this.InterestRate = interestRate;
        }

        public override string ToString()
        {
            return String.Format("{0} Balance: {1}", this.Customer, this.balance);
        }

        public virtual decimal CalculateInterest(Int32 months)
        {
            return months * this.InterestRate;
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
    }

    public enum CustomerType
    {
        Individual,
        Company
    }

    public class Customer
    {
        public CustomerType Type { get; set; }
        public string Name { get; set; }

        public Customer(CustomerType type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class DepositAccount : Account,IWithdraw
    {
        public DepositAccount(Customer customer,decimal balance,decimal interestRate)
        : base(customer,balance,interestRate){

        }

        void IWithdraw.Deposit(decimal amount)
        {
            if(this.balance < amount)
            {
                throw new InvalidOperationException();
            }

            this.balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if(this.Balance > 1000)
            {
                return base.CalculateInterest(months);
            }
            else
            {
                return 0;
            }
            
        }
    }

    class LoanAccount : Account
    {
        public LoanAccount(Customer customer,decimal balance,decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterest(int months)
        {
            if(this.Customer.Type == CustomerType.Company)
            {
                return this.CalculateCompanyAccountInterest(months);
            }
            else if (this.Customer.Type == CustomerType.Individual)
            {
                return this.CalculateIndividualAccountInterest(months);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private decimal CalculateIndividualAccountInterest(Int32 months)
        {
            const Int32 monthsWithoutInterest = 3;
            decimal interest = 0;
            if(months > monthsWithoutInterest)
            {
                interest += base.CalculateInterest(months - monthsWithoutInterest);
            }

            return interest;
        }

        private decimal CalculateCompanyAccountInterest(Int32 months)
        {
            const Int32 monthsWithoutInterest = 2;
            decimal interest = 0;
            if (months > monthsWithoutInterest)
            {
                interest += base.CalculateInterest(months - monthsWithoutInterest);
            }

            return interest;
        }
    }

    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Company)
            {
                return this.CalculateCompanyAccountInterest(months);
            }
            else if (this.Customer.Type == CustomerType.Individual)
            {
                return this.CalculateIndividualAccountInterest(months);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private decimal CalculateIndividualAccountInterest(Int32 months)
        {
            const Int32 monthsWithoutInterest = 6;
            decimal interest = 0;
            if (months > monthsWithoutInterest)
            {
                interest += base.CalculateInterest(months - monthsWithoutInterest);
            }

            return interest;
        }

        private decimal CalculateCompanyAccountInterest(Int32 months)
        {
            const Int32 monthsInAYear = 12;
            decimal interest = 0;
            interest += base.CalculateInterest(months % monthsInAYear) / 2;
            if (months > monthsInAYear)
            {
                interest += base.CalculateInterest(months - monthsInAYear);
            }

            return interest;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Int32 monthsToCalculateInterest = 0;
            List<string> input = new List<string>();
            List<Account> accounts = ParseInput(input);

            accounts.ForEach(a => Console.WriteLine("{0:0.0000}", a.CalculateInterest(monthsToCalculateInterest)));
        }

        private static List<string> ReadInput(ref Int32 monthsToCalculateInterest)
        {
            List<string> input = new List<string>();
            Int32 numberOfLines;

            string firstLineOfInput = Console.ReadLine();
            monthsToCalculateInterest = Int32.Parse(firstLineOfInput);
            string secondLine = Console.ReadLine();
            numberOfLines = Int32.Parse(Console.ReadLine());
            for(int lines = 0;lines < numberOfLines; lines++)
            {
                string line = Console.ReadLine();
                input.Add(line);
            }

            return input;
        }

        private static List<Account> ParseInput(List<string> input)
        {
            const Int32 accountTypeIndex = 0, accountNameIndex = 1, balanceIndex = 2,
                interestIndex = 3;
            Char[] separators = new Char[] { ' ' };
            List<Account> accounts = new List<Account>();
            foreach(string line in input)
            {
                String[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                switch (words[accountTypeIndex].ToLower())
                {
                    case "loanaccount":
                        LoanAccount loanAccount = new LoanAccount(new
                            Customer(CustomerType.Individual, words[accountNameIndex]), Decimal.Parse(words[balanceIndex]), Decimal.Parse(words[interestIndex]));
                        accounts.Add(loanAccount);
                        break;
                    case "depositaccount":
                        DepositAccount depositAccount = new DepositAccount(new
                            Customer(CustomerType.Individual, words[accountNameIndex]), Decimal.Parse(words[balanceIndex]), Decimal.Parse(words[interestIndex]));
                        accounts.Add(depositAccount);
                        break;
                    case "mortgageaccount":
                        MortgageAccount mortgageAccount = new MortgageAccount(new
                            Customer(CustomerType.Individual, words[accountNameIndex]), Decimal.Parse(words[balanceIndex]), Decimal.Parse(words[interestIndex]));
                        accounts.Add(mortgageAccount);
                        break;
                    default:
                        throw new ArgumentException("Unknown type!");
                }

                
            }

            return accounts;
        }
    }
}
