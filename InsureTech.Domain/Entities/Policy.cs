using System;

namespace InsureTech.Domain.Entities
{
    public class Policy
    {
        public int Id { get; set; }
        public int PolicyTypeId { get; set; } // Foreign key
        public PolicyType PolicyType { get; set; } // Navigation property

        public int PersonalInformationId { get; set; } // Foreign key
        public PersonalInformation PersonalInformation { get; set; } // Navigation property
    }
}
