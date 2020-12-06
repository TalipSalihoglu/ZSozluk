using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Contexts;
using ZSözlük.Entities;
using ZSözlük.IRepositories;

namespace ZSözlük.Repositories
{
    public class IcerikRepository : Repository<Icerik>, IIcerikRepository
    {
        public IcerikRepository(ZSozlukContext zSozlukContext) : base(zSozlukContext)
        {

        }
    }
}
