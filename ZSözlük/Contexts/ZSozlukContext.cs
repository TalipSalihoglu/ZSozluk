using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZSözlük.Entities;
using ZSözlük.Models;

namespace ZSözlük.Contexts
{
    public class ZSozlukContext :IdentityDbContext<ApplicationUser>
    {
        public ZSozlukContext(DbContextOptions<ZSozlukContext> options)
            : base(options)
        {

        }

        public DbSet<Konu> Konular { get; set; }
        public DbSet<Icerik> Icerikler { get; set; }
        public DbSet<LikeModel> Likes { get; set; }
    }
}
