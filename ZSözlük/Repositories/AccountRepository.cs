using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ZSözlük.IRepositories;
using ZSözlük.Models;
using ZSözlük.Models.ViewModel;

namespace ZSözlük.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.UserName,
                Age = userModel.Age,
                City = userModel.City,
                Country=userModel.Country,
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel) 
        {
            return await _signInManager.PasswordSignInAsync(signInModel.UserName, signInModel.Password, signInModel.RememberMe, false);
        }
        public async Task SignOutAsync() 
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> GetApplicationUserByid(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
        public async Task<IdentityResult> EditUser(ApplicationUser userModel) 
        {
             return await _userManager.UpdateAsync(userModel);         
        }
    }
}
