namespace InsureTech.Application.DTOs
{
    public class BuyPolicyDto
    {
        // Nullable annotations or default values should be provided for non-nullable properties

        public string? FullName { get; set; } // Nullable annotation added

        public DateTime? DateOfBirth { get; set; } // Nullable annotation added

        public string? NationalIdOrPassportNumber { get; set; } // Nullable annotation added

        public string? PhoneNumber { get; set; } // Nullable annotation added

        public string? EmailAddress { get; set; } // Nullable annotation added

        public string? ResidentialAddress { get; set; } // Nullable annotation added

        public string? Occupation { get; set; } // Nullable annotation added

        public int PolicyTypeId { get; set; } // Non-nullable properties should have default values or be nullable if appropriate
    }
}
