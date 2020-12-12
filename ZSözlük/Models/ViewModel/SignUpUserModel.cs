using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Models.ViewModel
{
    public class SignUpUserModel
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }

        [Required(ErrorMessage ="Lütfen e-mail adresinizi giriniz")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        [Compare("ConfirmPassword",ErrorMessage ="Şifreler eşleşmedi")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
