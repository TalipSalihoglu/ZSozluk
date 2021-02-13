using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Models;
using ZSözlük.Models.ViewModel;

namespace ZSözlük.IRepositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<ApplicationUser> GetApplicationUserByid(string id);
        Task<IdentityResult> EditUser(ApplicationUser userModel);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
    }
}
