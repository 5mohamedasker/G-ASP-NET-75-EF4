using EF_Assignment04.Operations;

namespace EF_Assignment04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            do
            {
                Console.WriteLine("================================");
                Console.WriteLine("National Bamk - Managment");
                Console.WriteLine("================================");
                Console.WriteLine("1) Add a new Customer");
                Console.WriteLine("2) Open a new Account for a Customer");
                Console.WriteLine("3) Update Account Status (Active / Closed)");
                Console.WriteLine("4) Remove an Account from a Customer");
                Console.WriteLine("5) List all Customers (with accounts)");
                Console.WriteLine("0) Exit");
                Console.WriteLine("--------------------------------");
                bool result;
                do
                {
                    Console.Write("Enter choice: ");
                    result = int.TryParse(Console.ReadLine(), out userInput);
                } while (!(result && userInput <= 5 && userInput >= 0 ));

                if (userInput == 1)
                    CustomerOperations.AddNewCustomer();
            
                else if (userInput == 2)
                    AccountOperations.OpenNewAccount();
            
                else if (userInput == 3)
                    AccountOperations.UpdateAccountStatus();
            
                else if (userInput == 4)
                    AccountOperations.RemoveAccount();
            
                else if (userInput == 5)
                    CustomerOperations.AllCustomers();
            
                else if (userInput == 0)
                    return;
        
            } while (true);

        }
    }
}
