using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Entities
{
    public class Konu
    {
        public int KonuID { get; set; }
        [Required(ErrorMessage ="Boş geçilemez")]
        [MaxLength(75)]
        public string KonuBaslık { get; set; }
        public List<Icerik> Icerikler { get; set; }
    }
}
