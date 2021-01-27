using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Entities;

namespace ZSözlük.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public DateTime? DateOfBirth{ get; set; }
        public string Photo { get; set; }
        public int Age{ get; set; }
        public string Country{ get; set; }
        public string City{ get; set; }
        public string Link_insta { get; set; }
        public string Link_facebook { get; set; }
        public string Link_twitter { get; set; }
        public List<Icerik> Icerikler { get; set; }

    }
}
