using EF_Assignment04.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Models
{
    internal class AccountCustomer
    {
        public DateTime StartDate { get; set; }
        public OwnershipType OwnershipType { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public int AccountNumber { get; set; }
        public Account Account { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
