using EF_Assignment04.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Nationalld { get; set; }

        public ICollection<AccountCustomer> AccountCustomers { get; set; }
    }
}
