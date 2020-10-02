using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Contexts;
using ZSözlük.Entities;

namespace ZSözlük.Repository
{
    public class KonuRepository
    {
        private readonly ZSozlukContext _context;
        public KonuRepository(ZSozlukContext context)
        {
            _context = context;
        }
        public async Task<List<Konu>> GetirHepsiKonu() 
        {
            var list = await _context.Konular.ToListAsync();
            return list;
        }
        public void Ekle(Konu konu) 
        {
            _context.Add(konu);
            _context.SaveChanges();
        }
    }
}
