using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Contexts;
using ZSözlük.IRepositories;
using ZSözlük.Repositories;

namespace ZSözlük
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ZSozlukContext _context;
        private IcerikRepository _icerikRepository;
        private KonuRepository _konuRepository;

        public UnitOfWork(ZSozlukContext context)
        {
            this._context = context;
        }


        public IIcerikRepository Icerikler => _icerikRepository=_icerikRepository ?? new IcerikRepository(_context);

        public IKonuRepository Konular => _konuRepository = _konuRepository ?? new KonuRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
           _context.Dispose();
            _icerikRepository = null;
            _konuRepository = null;
        }
    }
}
