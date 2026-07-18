


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

        public string Country { get; }

        public string Currency { get; }

        public string AuthenticationType { get; }
        // The base URL for the bank's API.
        // We'll use this later when simulating API calls.
        public string BaseUrl { get; }

        // Indicates whether the bank requires a client certificate.
        public bool CertificateRequired { get; }

        public bool IsActive { get; }

        // The constructor is automatically called whenever we create a new Bank object.
        // It receives the values needed to initialize the object.
        public Bank(
            string name,
            string code,
            string country,
            string currency,
            string authenticationType,
            string baseUrl,
            bool certificateRequired,
            bool isActive)
        {
            // Store the provided name in the Name property.
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Bank name cannot be empty", nameof(name));
            }
            Name = name;

            // Store the provided code.
            if(string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Bank code cannot be empty", nameof(code));
            }
            Code = code;

            if(string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException("Bank Country cannot be empty", nameof(country));
            }
            Country = country;


            if(string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException("Bank currency cannot be empty", nameof(currency));
            }
            Currency = currency;


            if(string.IsNullOrWhiteSpace(authenticationType))
            {
                throw new ArgumentException("Bank authenticationType cannot be empty", nameof(authenticationType));
            }
            AuthenticationType = authenticationType;

            // Store the API base URL.
            if(string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("Bank baseUrl cannot be empty", nameof(baseUrl));
            }
            BaseUrl = baseUrl;

            // Store whether this bank requires a certificate.
            CertificateRequired = certificateRequired;

            IsActive = isActive;
        }
    }
}
