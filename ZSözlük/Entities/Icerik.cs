using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Entities
{
    public class Icerik
    {
        public int IcerikID { get; set; }
        [Required]
        public string IcerikFull{ get; set; }
        [Required]
        public int KonuID { get; set; }
        public virtual Konu Konu { get; set; }

    }
}
