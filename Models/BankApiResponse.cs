namespace BankIntegrationSimulator.Models
{
    public class BankApiResponse<T>
    {
        public bool Success { get; set; }

        public string? ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        public T? Data { get; set; }
    }
}