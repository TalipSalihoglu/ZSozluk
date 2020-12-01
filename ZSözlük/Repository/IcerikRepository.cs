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
        public IQueryable<Icerik> GetirİcerikHepsi() 
        {
            var list = _zSozlukContext.Icerikler.OrderByDescending(I=>I.IcerikID); //.ToListAsync(),await, task;
            return list;
        }
        public IQueryable<Icerik> GetirİcerikIdile(int id)
        {
            var list =  _zSozlukContext.Icerikler.Where(i => i.KonuID == id).OrderByDescending(I => I.IcerikID);//ToListAsync();
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
