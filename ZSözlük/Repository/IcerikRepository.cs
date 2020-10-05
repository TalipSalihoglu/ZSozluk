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
            var list = await _zSozlukContext.Icerikler.OrderByDescending(I=>I.IcerikID).ToListAsync(); 
            return list;
        }
        public async Task<List<Icerik>> GetirİcerikIdile(int id)
        {
            var list = await _zSozlukContext.Icerikler.Where(i=>i.KonuID==id).OrderByDescending(I => I.IcerikID).ToListAsync();
            return list;
        }
        public void Ekle(Icerik model) 
        {
            model.IcerikTarih = DateTime.Now;
            _zSozlukContext.Add(model);
            _zSozlukContext.SaveChanges();
        }
    }
}
