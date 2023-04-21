using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.View_Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeLeaveManagement.Contracts
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel model);

        Task<SignInResult> PasswordSignInAsync(SignInModel model);

        Task SignOutAsync();

    }
}