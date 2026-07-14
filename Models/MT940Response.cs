
namespace BankIntegrationSimulator.Models
{
    public class MT940Response
    {
        public string AccountNumber { get; set;} = "";

        public DateTime StatementDate { get; set;} 

        public decimal OpeningBalance { get; set;}

        public decimal ClosingBalance { get; set;}

        public string Currency { get; set;} = "";

        public string Status { get; set;} = "";

        public string Message { get; set;} = "";

        public Guid RequestId { get; set;}


    }
}
