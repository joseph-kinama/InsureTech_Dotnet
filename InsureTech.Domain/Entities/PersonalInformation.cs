using System;

namespace InsureTech.Domain.Entities
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public int PolicyId { get; set; } // Foreign key
        public Policy Policy { get; set; } // Navigation property

        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdOrPassportNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public string Occupation { get; set; }
        // Add any other properties related to personal information
    }
}
