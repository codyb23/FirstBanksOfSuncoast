using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
    class TransactionsController
    {
        private List<Transaction> Transactions = new List<Transaction>();
        public decimal CheckingAccountValue { get; set; }
        public decimal SavingsAccountValue { get; set; }

        public void SaveAllTransactions()
        {
            var writer = new StreamWriter("Transactions.csv");

            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(Transactions);

            writer.Close();
        }

        public void LoadAllTransactions()
        {
            if (File.Exists("transactions.csv"))
            {
                var reader = new StreamReader("transactions.csv");

                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                Transactions = csvReader.GetRecords<Transaction>().ToList();

            }
        }



        public void DisplayCheckingAccountBalance()
        {


            var checkingTransaction = Transactions.Where(transactions => transactions.AccountId == 1).ToList();
            var withdrawTotalValue = checkingTransaction.Where(transactions => transactions.TransactionType == "Withdraw");
            var depositTotalValue = checkingTransaction.Where(transactions => transactions.TransactionType == "Deposit");
            var withdrawTotal = withdrawTotalValue.Sum(transactions => transactions.Amount);
            var depositTotal = depositTotalValue.Sum(transactions => transactions.Amount);

            CheckingAccountValue = depositTotal - withdrawTotal;

            Console.WriteLine($"Your current balance of your checking account is {CheckingAccountValue}");
        }

        public void DisplaySavingsAccountBalance()
        {
            var savingsTransaction = Transactions.Where(transactions => transactions.AccountId == 2).ToList();
            var withdrawTotalValue = savingsTransaction.Where(transactions => transactions.TransactionType == "Withdraw");
            var depositTotalValue = savingsTransaction.Where(transactions => transactions.TransactionType == "Deposit");
            var withdrawTotal = withdrawTotalValue.Sum(transactions => transactions.Amount);
            var depositTotal = depositTotalValue.Sum(transactions => transactions.Amount);

            SavingsAccountValue = depositTotal - withdrawTotal;

            Console.WriteLine($"Your current balance of your savings account is {SavingsAccountValue}");
        }

        internal void DepositChecking(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }

        internal void WithdrawChecking(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }

        internal void WithdrawSavings(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }

        internal void DepositSavings(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }
    }
}