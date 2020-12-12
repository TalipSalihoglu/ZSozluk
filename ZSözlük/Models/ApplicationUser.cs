﻿using Microsoft.AspNetCore.Identity;
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

        public List<Icerik> Icerikler { get; set; }

    }
}
