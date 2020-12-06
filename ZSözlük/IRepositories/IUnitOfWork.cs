using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.IRepositories
{
    public interface IUnitOfWork:IDisposable
    {
        IIcerikRepository Icerikler{ get; }
        IKonuRepository Konular{ get; }
        Task<int> CommitAsync();
    }
}
