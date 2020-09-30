using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Entities
{
    public class Icerik
    {
        public int IcerikID { get; set; }
        public string IcerikFull{ get; set; }
        public int KonuID { get; set; }
        public virtual Konu Konu { get; set; }

    }
}
