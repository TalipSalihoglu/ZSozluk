﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
                LastName=userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.UserName, 
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel) 
        {
            return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
        }
    }
}
