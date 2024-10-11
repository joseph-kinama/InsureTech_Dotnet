using System.Collections.Generic;
using InsureTech.Application.DTOs;

namespace InsureTech.Application.ViewModels
{
    public class BuyPolicyViewModel
    {
        // Nullable annotations or default values should be provided for non-nullable properties

        public BuyPolicyDto? Policy { get; set; } // Nullable annotation added

        public List<PolicyTypeDto>? PolicyTypes { get; set; } // Nullable annotation added

        // Constructor should initialize collections if needed
        public BuyPolicyViewModel()
        {
            Policy = new BuyPolicyDto(); // Initialize Policy if necessary
            PolicyTypes = new List<PolicyTypeDto>(); // Initialize PolicyTypes if necessary
        }
    }
}
