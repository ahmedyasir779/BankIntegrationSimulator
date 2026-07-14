using BankIntegrationSimulator.Models;
using BankIntegrationSimulator.Services;

class Program
{
    static void Main()
    {
        // PHP
        // $bankService = new BankService();
        // $response = $bankService->getBalance($bank, $accountNumber);

        // Create one BankService object that will be reused.
        BankService bankService = new BankService();

        bool restartApplication;

        do
        {

            DisplayWelcomeScreen();

            Bank selectedBank = ReadBankSelection();

            DisplayServiceMenu();

            string service = ReadServiceSelection();

            switch (service)
            {
                case "Balance":

                    string accountNumber = ReadAccountNumber();

                    // Ask the service to perform the balance inquiry.
                    BalanceResponse response = bankService.GetBalance(selectedBank, accountNumber);

                    // Display the returned information.
                    DisplayBalanceResult(selectedBank, response);
                    break;

                case "MT940":

                    DisplayMt940Message();

                    break;

                case "Exit":
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using Bank Integration Simulator.");
                    return;
            }

            Console.WriteLine();
            Console.Write("Would you like to perform another operation? (Y/N): ");

            string? answer = Console.ReadLine();

            restartApplication =
                answer?.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase) == true;

        } while (restartApplication);

        Console.WriteLine();
        Console.WriteLine("Thank you for using Bank Integration Simulator.");
    }


    static void DisplayWelcomeScreen()
    {
        Console.WriteLine("==================================");
        Console.WriteLine(" Bank Integration Simulator");
        Console.WriteLine("==================================");
    }


    static Bank ReadBankSelection()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Available Banks");
            Console.WriteLine("1. SNB");
            Console.WriteLine("2. Al Rajhi");
            Console.WriteLine("3. Riyad");
            Console.WriteLine("4. Mock Bank");
            Console.WriteLine();

            Console.Write("Select Bank: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return new Bank("Saudi National Bank", "SNB", "https://api.snb.com", true);

                case "2":
                    return new Bank("Al Rajhi", "RJHI", "https://api.alrajhi.com", true);

                case "3":
                    return new Bank("Al Riyad", "RIYAD", "https://api.riyadbank.com", true);

                case "4":
                    return new Bank("Mock Bank", "MOCK", "https://api.mock.com", true);

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid bank selection. Please try again.");
                    break;
            }
        }
    }


    static void DisplayServiceMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Available Services");
        Console.WriteLine("1. Balance Inquiry");
        Console.WriteLine("2. MT940 Statement");
        Console.WriteLine("3. Exit");
        Console.WriteLine();
    }


    static string ReadServiceSelection()
    {
        while (true)
        {
            Console.Write("Select Service: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return "Balance";

                case "2":
                    return "MT940";

                case "3":
                    return "Exit";

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid service selection.");
                    break;
            }
        }
    }


    static string ReadAccountNumber()
    {
        while (true)
        {
            Console.Write("Enter Account Number: ");

            string accountNumber = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(accountNumber))
            {
                return accountNumber;
            }

            Console.WriteLine("Account number cannot be empty.");
        }
    }


    static void DisplayBalanceResult(Bank bank, BalanceResponse response)
    {
        Console.WriteLine();
        Console.WriteLine($"Request Id     : {Guid.NewGuid()}");
        Console.WriteLine($"Bank Name      : {bank.Name}");
        Console.WriteLine($"Bank Code      : {bank.Code}");
        Console.WriteLine();
        Console.WriteLine("Connecting...");

        Console.WriteLine("Balance Inquiry Completed");
        Console.WriteLine();

        Console.WriteLine($"Account Number : {response.AccountNumber}");
        Console.WriteLine($"Currency       : {response.Currency}");
        Console.WriteLine($"Balance        : {response.Balance:N2}");

        Console.WriteLine();
        Console.WriteLine($"Status         : {response.Status}");
    }


    static void DisplayMt940Message()
    {
        Console.WriteLine();
        Console.WriteLine("Feature coming in future versions.");
    }
}