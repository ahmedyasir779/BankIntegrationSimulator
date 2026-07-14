
namespace BankIntegrationSimulator.Models
{
    public class BankResponse
    {
        public string AccountNumber { get; set; } = "";

        public decimal Balance { get; set; } 

        public string Currency { get; set; } = "";

        public string Status { get; set; } = "";


    }
}
