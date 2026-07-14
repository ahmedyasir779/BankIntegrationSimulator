


namespace BankIntegrationSimulator.Models
{
    // This class represents a single bank.
    // Every bank object (SNB, Al Rajhi, Riyad, Mock) will be created from this blueprint.
    public class Bank
    {
        // The bank's display name.
        // { get; } makes this property read-only after the object is created.
        public string Name { get; }

        // A short unique code used by systems.
        // Example: SNB, RJHI, RIYAD.
        public string Code { get; }

        // The base URL for the bank's API.
        // We'll use this later when simulating API calls.
        public string BaseUrl { get; }

        // Indicates whether the bank requires a client certificate.
        public bool CertificateRequired { get; }

        // The constructor is automatically called whenever we create a new Bank object.
        // It receives the values needed to initialize the object.
        public Bank(
            string name,
            string code,
            string baseUrl,
            bool certificateRequired)
        {
            // Store the provided name in the Name property.
            Name = name;

            // Store the provided code.
            Code = code;

            // Store the API base URL.
            BaseUrl = baseUrl;

            // Store whether this bank requires a certificate.
            CertificateRequired = certificateRequired;
        }
    }
}
