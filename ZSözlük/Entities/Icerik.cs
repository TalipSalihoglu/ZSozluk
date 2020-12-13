using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Models;

namespace ZSözlük.Entities
{
    public class Icerik
    {
        public int IcerikID { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string IcerikFull{ get; set; }
        [Required]
        public int KonuID { get; set; }
        public DateTime IcerikTarih { get; set; }
        public virtual Konu Konu { get; set; }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
