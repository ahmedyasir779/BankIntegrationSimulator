using BankIntegrationSimulator.Models;
using BankIntegrationSimulator.Services;
using BankIntegrationSimulator.Data;

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
        List<Bank> banks = BankFactory.GetBanks();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Available Banks");

            for (int i = 0; i < banks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {banks[i].Name}");
            }

            Console.WriteLine();

            Console.Write("Select Bank: ");

            string? choice = Console.ReadLine();

            if (int.TryParse(choice, out int selectedIndex))
            {
                if (selectedIndex >= 1 && selectedIndex <= banks.Count)
                {
                    return banks[selectedIndex - 1];
                }

                Console.WriteLine();
                Console.WriteLine("Invalid bank selection. Please try again.");
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