using EF_Assignment04.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Models
{
    internal class Transaction
    {
        public int TransactionNumber { get; set; }
        public DateOnly TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Note { get; set; }

        public int AccountNumber { get; set; }
        public Account Account { get; set; }

    }
}
