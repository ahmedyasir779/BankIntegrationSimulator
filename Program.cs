Console.WriteLine("==================================");
Console.WriteLine(" Bank Integration Simulator");
Console.WriteLine("==================================");

string selectedBank = "";

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

    string? bankChoice = Console.ReadLine();

    switch (bankChoice)
    {
        case "1":
            selectedBank = "SNB";
            break;
        case "2":
            selectedBank = "Al Rajhi";
            break;
        case "3":
            selectedBank = "Riyad";
            break;
        case "4":
            selectedBank = "Mock Bank";
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("Invalid bank selection. Please try again.");
            continue;
    }

    break;
}

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Available Services");
    Console.WriteLine("1. Balance Inquiry");
    Console.WriteLine("2. MT940 Statement");
    Console.WriteLine("3. Exit");
    Console.WriteLine();

    Console.Write("Select Service: ");
    string? serviceChoice = Console.ReadLine();

    switch (serviceChoice)
    {
        case "1":

            string accountNumber = "";

            while (true)
            {
                Console.Write("Enter Account Number: ");
                accountNumber = Console.ReadLine() ?? "";

                if (accountNumber != "")
                {
                    break;
                }

                Console.WriteLine("Account number cannot be empty.");
            }

            Console.WriteLine();
            Console.WriteLine($"Connecting to {selectedBank}...");
            Console.WriteLine();
            Console.WriteLine("Balance Inquiry Completed");
            Console.WriteLine();
            Console.WriteLine($"Account Number : {accountNumber}");
            Console.WriteLine("Currency       : SAR");
            Console.WriteLine("Balance        : 15,350.00");
            Console.WriteLine();
            Console.WriteLine("Status         : Success");

            break;

        case "2":
            Console.WriteLine();
            Console.WriteLine("Feature coming in future versions.");
            break;

        case "3":
            Console.WriteLine();
            Console.WriteLine("Thank you for using Bank Integration Simulator.");
            break;

        default:
            Console.WriteLine();
            Console.WriteLine("Invalid service selection.");
            continue;
    }

    break;
}