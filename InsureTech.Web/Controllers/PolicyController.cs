using InsureTech.Application.DTOs;
using InsureTech.Application.Interfaces;
using InsureTech.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsureTech.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : Controller // Change here: inherit from Controller
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet("Buy")]
        public IActionResult Buy()
        {
            var viewModel = new BuyPolicyDto();
            ViewBag.PolicyTypes = _policyService.GetPolicyTypes().Select(pt => new PolicyTypeDto { Id = pt.Id, Name = pt.Name }).ToList();
            return View(viewModel);
        }

        [HttpPost("Buy")]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(BuyPolicyDto viewModel)
        {
            if (ModelState.IsValid)
            {
                var policyType = _policyService.GetPolicyTypes().FirstOrDefault(pt => pt.Id == viewModel.PolicyTypeId);
                if (policyType == null)
                {
                    ModelState.AddModelError("PolicyTypeId", "Invalid policy type selected.");
                    ViewBag.PolicyTypes = _policyService.GetPolicyTypes().Select(pt => new PolicyTypeDto { Id = pt.Id, Name = pt.Name }).ToList();
                    return View(viewModel);
                }

                var policy = new Policy
                {
                    PolicyType = new PolicyType { Id = policyType.Id, Name = policyType.Name },
                    PersonalInformation = new PersonalInformation
                    {
                        FullName = viewModel.FullName,
                        DateOfBirth = viewModel.DateOfBirth ?? default,
                        NationalIdOrPassportNumber = viewModel.NationalIdOrPassportNumber,
                        PhoneNumber = viewModel.PhoneNumber,
                        EmailAddress = viewModel.EmailAddress,
                        ResidentialAddress = viewModel.ResidentialAddress,
                        Occupation = viewModel.Occupation
                    }
                };

                _policyService.AddPolicy(policy);

                TempData["SuccessMessage"] = "Policy purchased successfully!";
                return RedirectToAction(nameof(Buy));
            }

            TempData["ErrorMessage"] = "There was an error processing your request.";
            ViewBag.PolicyTypes = _policyService.GetPolicyTypes().Select(pt => new PolicyTypeDto { Id = pt.Id, Name = pt.Name }).ToList();
            return View(viewModel);
        }

        [HttpGet("MyPolicies")]
        public IActionResult MyPolicies()
        {
            var policies = _policyService.GetPolicies();
            return View(policies);
        }
    }
}
