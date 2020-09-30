using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZSözlük.Entities;

namespace ZSözlük.Contexts
{
    public class ZSozlukContext :IdentityDbContext
    {
        public ZSozlukContext(DbContextOptions<ZSozlukContext> options)
            : base(options)
        {

        }

        public DbSet<Konu> Konular { get; set; }
        public DbSet<Icerik> Icerikler { get; set; }
    }
}
