using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Models.ViewModel
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password),Display(Name ="Kullanılan şifre")]
        public string CurrentPassword{ get; set; }
        [Required]
        [DataType(DataType.Password), Display(Name = "Yeni şifre")]
        public string NewPassword{ get; set; }
        [Required]
        [DataType(DataType.Password), Display(Name = "Tekrar yeni şifre")]
        [Compare("NewPassword",ErrorMessage ="Şifreler eşleşmedi")]
        public string ConfirmNewPassword{ get; set; }
    }
}
