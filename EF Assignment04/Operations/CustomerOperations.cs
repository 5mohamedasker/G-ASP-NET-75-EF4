using EF_Assignment04.Contexts;
using EF_Assignment04.Enums;
using EF_Assignment04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Operations
{
    internal class CustomerOperations
    {
        public static void AddNewCustomer()
        {
            using AssignmentDbContext db = new AssignmentDbContext();

            string fullName, nationalId;
            DateOnly DOB;
            string email, phone, address;
            CustomerType customerType;

            bool isValid;
            Console.WriteLine("--- Add New Customer ---");
            do
            {
                Console.Write("Full Name     : ");
                fullName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(fullName) || fullName.Length < 5);

            do
            {
                Console.Write("National ID   : ");
                nationalId = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length < 14);

            do
            {
                Console.Write("Date Of Birth :(MM-dd-yyyy) ");
                isValid = DateOnly.TryParse( Console.ReadLine(),out DOB) && DOB < DateOnly.FromDateTime(DateTime.Now) ;
            } while (!isValid);

            do
            {
                Console.Write("Email         : ");
                email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(email) || email.Length < 5);
            do
            {
                Console.Write("Phone         : ");
                phone = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(phone));

            do
            {
                Console.Write("Address       : ");
                address = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(address) || address.Length < 5);


            do
            {
                Console.Write($"Customer Type :" +
                              "\n\t1) Individual" +
                              "\n\t2) Business" +
                              "\n\tChoice: ");
                isValid = Enum.TryParse(Console.ReadLine(), out customerType) && Enum.IsDefined(customerType);
            } while (!isValid);

            Customer customer = new Customer()
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                DateOfBirth = DOB,
                CustomerType = customerType,
                Nationalld = nationalId
            };
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                Console.WriteLine($"Customer created successfully. CustomerId = {customer.Id}");

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }

        public static void AllCustomers()
        {
            using AssignmentDbContext db = new AssignmentDbContext();

            Console.WriteLine("--- All Customers ---");
            var allCustomers = db.Customers.Include(C => C.AccountCustomers).ThenInclude(AC => AC.Account).ThenInclude(A => A.Branch).ToList();

            int num = 1;
            foreach(var C in allCustomers)
            {
                Console.WriteLine($"#{num} {C.FullName} ({C.CustomerType})");
                foreach (var AC in C.AccountCustomers)
                {
                    Console.Write($"{AC.Account.BranchCode}\t{AC.Account.AccountType}\tBalance:  {AC.Account.CurrentBalance}\t{AC.OwnershipType}\t{AC.AccountStatus} @ {AC.Account.Branch.Name}");
                }
                num++;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
