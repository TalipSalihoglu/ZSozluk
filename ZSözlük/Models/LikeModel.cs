using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Models
{
    public class LikeModel
    {
        public int LikeModelID { get; set; }
        public string UserID { get; set; }
        public int IcerikID { get; set; }
    }
}
