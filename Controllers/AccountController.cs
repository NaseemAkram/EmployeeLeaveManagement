using EmployeeLeaveManagement.Contracts;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountrepository;

        public AccountController(IAccountRepository accountrepository)
        {
            _accountrepository = accountrepository;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountrepository.CreateUserAsync(model);

                if (!result.Succeeded)
                {
                    foreach (var errormessage in result.Errors)
                    {
                        ModelState.AddModelError("", errormessage.Description);
                    }
                }
                ModelState.Clear();
            }

            return View();
        }


        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountrepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Model Credential");
            }

            return View(signInModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _accountrepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
