// InsureTech.Infrastructure/Services/PolicyService.cs
using InsureTech.Application.Interfaces;
using InsureTech.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace InsureTech.Infrastructure.Services
{
    public class PolicyService : IPolicyService
    {
        private static List<PolicyType> policyTypes = new List<PolicyType>
        {
            new PolicyType { Id = 1, Name = "Motor Vehicle" },
            new PolicyType { Id = 2, Name = "Third Party" },
            new PolicyType { Id = 3, Name = "Domestic Package" }
        };

        private static List<Policy> policies = new List<Policy>();

        public List<PolicyType> GetPolicyTypes()
        {
            return policyTypes;
        }

        public void AddPolicy(Policy policy)
        {
            policy.Id = policies.Count + 1;
            policies.Add(policy);
        }

        public List<Policy> GetPolicies()
        {
            return policies;
        }
    }
}
