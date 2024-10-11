// InsureTech.Application/Interfaces/IPolicyService.cs
using InsureTech.Domain.Entities;
using System.Collections.Generic;

namespace InsureTech.Application.Interfaces
{
    public interface IPolicyService
    {
        List<PolicyType> GetPolicyTypes();
        void AddPolicy(Policy policy);
        List<Policy> GetPolicies();
    }

}
