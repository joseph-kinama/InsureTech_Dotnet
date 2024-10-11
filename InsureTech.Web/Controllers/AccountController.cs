using InsureTech.Application.DTOs;
using InsureTech.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InsureTech.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(userDto);
                return RedirectToAction("Login");
            }
            return View(userDto);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userService.Login(username, password);
            if (user != null)
            {
                // Handle successful login (e.g., set cookies or session)
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }
    }

}
