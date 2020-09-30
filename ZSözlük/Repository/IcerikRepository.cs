using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Contexts;
using ZSözlük.Entities;

namespace ZSözlük.Repository
{
    public class IcerikRepository
    {
        private readonly ZSozlukContext _zSozlukContext;

        public IcerikRepository(ZSozlukContext zSozlukContext)
        {
            _zSozlukContext = zSozlukContext;
        }
        public async Task<List<Icerik>> GetirİcerikHepsi() 
        {
            var list = await _zSozlukContext.Icerikler.ToListAsync();
            return list;
        }
        public async Task<List<Icerik>> GetirİcerikIdile(int id)
        {
            var list = await _zSozlukContext.Icerikler.Where(i=>i.KonuID==id).ToListAsync();
            return list;
        }
    }
}
