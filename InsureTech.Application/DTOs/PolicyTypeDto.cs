// InsureTech.Application.DTOs.PolicyTypeDto.cs

namespace InsureTech.Application.DTOs
{
    public class PolicyTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Optionally, you can add more properties here if needed

        public PolicyTypeDto()
        {
            // Default constructor is often used in DTOs
        }

        public PolicyTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
