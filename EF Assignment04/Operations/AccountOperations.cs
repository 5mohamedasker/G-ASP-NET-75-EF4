using EF_Assignment04.Contexts;
using EF_Assignment04.Enums;
using EF_Assignment04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Operations
{
    internal class AccountOperations
    {
        public static void OpenNewAccount()
        {
            using AssignmentDbContext db = new AssignmentDbContext();

            AccountType accountType;
            int branchCode;

            bool isValid;
            
            Console.WriteLine("--- Open New Account ---");

            do
            {
                Console.Write($"Account Type :" +
                              "\n\t\t 1) Saving" +
                              "\n\t\t 2) Current" +
                              "\n\t\t 3) Business" +
                              "\n\tChoice: ");
                isValid = Enum.TryParse(Console.ReadLine(), out accountType) && Enum.IsDefined(accountType);
            } while (!isValid);

            do
            {
                Console.WriteLine("Branch Code     : ");
                isValid = int.TryParse(Console.ReadLine(), out branchCode);

            } while (!(isValid && db.Branches.Any(B => B.Code == branchCode)));

            Account account = new Account()
            {
                CurrentBalance = 0,
                AccountType = accountType, 
                OpeningDate = DateTime.Now,
                BranchCode = branchCode
            };

            int customerId;
            OwnershipType ownershipType;

            do
            {
                Console.WriteLine("Customer Id     : ");
                isValid = int.TryParse(Console.ReadLine(), out customerId);

            } while (!(isValid && db.Customers.Any(C => C.Id == customerId)));

            do
            {
                Console.Write($"Ownership Role :" +
                              "\n\t\t 1) Primary" +
                              "\n\t\t 2) CoHolder" +
                              "\n\tChoice: ");
                isValid = Enum.TryParse(Console.ReadLine(), out ownershipType) && Enum.IsDefined(ownershipType);
            } while (!isValid);

            AccountCustomer accountCustomer = new AccountCustomer()
            {
                StartDate = account.OpeningDate,
                OwnershipType = ownershipType,
                AccountStatus = AccountStatus.Active,
                Account = account,
                CustomerId = customerId
            };

            Console.WriteLine($"Validating branch '{branchCode}' and customer #{customerId}...");

            try
            {
                db.Accounts.Add(account);
                db.AccountCustomers.Add(accountCustomer);
                db.SaveChanges();

                Console.WriteLine($"Account with Number '{account.AccountNumber}' created and linked to customer {customerId} as {ownershipType} owner.");

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

        public static void UpdateAccountStatus()
        {
            using AssignmentDbContext db = new AssignmentDbContext();

            int customerId , accountNumber;
            AccountStatus newAccountStatus;

            bool isValid;

            Console.WriteLine("--- Update Account Status ---");

            do
            {
                Console.WriteLine("Account Number     : ");
                isValid = int.TryParse(Console.ReadLine(), out accountNumber);

            } while (!isValid);

            do
            {
                Console.WriteLine("Customer Id     : ");
                isValid = int.TryParse(Console.ReadLine(), out customerId);

            } while (!isValid);



            do
            {
                Console.Write($"New Status :" +
                              "\n\t\t 1) Active" +
                              "\n\t\t 2) Closed" +
                              "\n\tChoice: ");
                isValid = Enum.TryParse(Console.ReadLine(), out newAccountStatus) && Enum.IsDefined(newAccountStatus);
            } while (!isValid);

            try
            {
                var accountCustomer = db.AccountCustomers.Find(accountNumber, customerId);
                if(accountCustomer is null)
                {
                    Console.WriteLine($"Ther is no Account with Account Number '{accountNumber}' and Customer Id '{customerId}'");

                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    return;
                }

                if( accountCustomer.AccountStatus == newAccountStatus)
                {
                    Console.WriteLine($"Account Status is already '{newAccountStatus}'");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    return;
                }

                accountCustomer.AccountStatus = newAccountStatus;
                db.SaveChanges();

                Console.WriteLine($"Status updated to '{newAccountStatus}'");
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

        public static void RemoveAccount()
        {
            using AssignmentDbContext db = new AssignmentDbContext();

            int customerId, accountNumber;

            bool isValid;

            Console.WriteLine("--- Remove Account From Customer ---");

            do
            {
                Console.WriteLine("Account Number     : ");
                isValid = int.TryParse(Console.ReadLine(), out accountNumber);

            } while (!isValid);

            do
            {
                Console.WriteLine("Customer Id     : ");
                isValid = int.TryParse(Console.ReadLine(), out customerId);

            } while (!isValid);

            try
            {
                var accountCustomer = db.AccountCustomers.Find(accountNumber, customerId);
                if (accountCustomer is null)
                {
                    Console.WriteLine($"Ther is no Account with Account Number '{accountNumber}' and Customer Id '{customerId}'");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    return;
                }

                db.AccountCustomers.Remove(accountCustomer);
                db.SaveChanges();

                Console.WriteLine($"Deleted successfully");
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
    }
}
