using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZSözlük.IRepositories;
using ZSözlük.Models.ViewModel;

namespace ZSözlük.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        //[Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View();
                }
                ModelState.Clear();
                return RedirectToAction("Index", "Sozluk");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Sozluk");
                }
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
            }
            return View(signInModel);
        }

        public async Task<ActionResult> Logout() 
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Sozluk");
        }

        [HttpPost]
        public async Task<ActionResult> EditPersonalinfo(EditUserViewModel modelUser)
        {
            var user = await _accountRepository.GetApplicationUserByid(modelUser.Id);

            user.Id= modelUser.Id;
            user.Email = modelUser.Email;
            user.FirstName = modelUser.FirstName;
            user.LastName = modelUser.LastName;
            user.Age = modelUser.Age;
            user.City = modelUser.City;
            user.Country = modelUser.Country;
                    
            await _accountRepository.EditUser(user);

            return RedirectToAction("MyProfile","Sozluk"); 
        }
    }
}
