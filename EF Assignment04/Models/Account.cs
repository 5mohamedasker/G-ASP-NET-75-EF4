using EF_Assignment04.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Models
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpeningDate { get; set; }

        public int BranchCode { get; set; }
        public Branch Branch { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<AccountCustomer> AccountCustomers { get; set; }

    }
}
