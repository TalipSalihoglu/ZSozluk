﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Models.ViewModel
{
    public class SignInModel
    {
        //[Required,EmailAddress]
        //public string Email{ get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
