using System;
using System.Collections.Generic;

namespace Latihan.Data
{

    public class BankAccount
    {
        public List<Transaction> allTransaction = new List<Transaction>();
        private static int accountNumberSeed = 123456789;
        public string Number { get; }
        public string Owner { get; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransaction)
                {
                    balance = balance + item.Amount;
                }
                return balance;
            }
        }

        /// penyetoran
        /// nasabah, dan mencek amount yang > 0.
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount> 0 )
            {
                allTransaction.Add(new Transaction(amount, date, note));
            }
        }
        /// penarikan.
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if((Balance - amount) >= 0){
                allTransaction.Add(new Transaction(-amount, date, note));
            }
            else{
               // throw new Exception("Jumlah yang ditarik > saldo.");
               System.Console.WriteLine("Error : Jumlah yang ditarik > saldo.");
            }
        }

        public BankAccount(string name, decimal initBalance)
        {
            Owner = name;
            
            
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initBalance, DateTime.Now, "Initial balance");
        }
    }
    
}