using EmployeeLeaveManagement.Contracts;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.View_Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeLeaveManagement.Repositroy
{
    public class AccountRepository : IAccountRepository
    {

        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _signinmanager;

        public AccountRepository(UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel model)
        {
            var user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email



            };
            var result = await _usermanager.CreateAsync(user, model.Password);
            return result;
        }


        public async Task<SignInResult> PasswordSignInAsync(SignInModel model)
        {
            var result = await _signinmanager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, false);
            return result;

        }

        public async Task SignOutAsync()
        {
            await _signinmanager.SignOutAsync();
        }
    }
}
