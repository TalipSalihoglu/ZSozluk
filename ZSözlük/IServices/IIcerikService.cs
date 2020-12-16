using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Entities;

namespace ZSözlük.Services
{
    public interface IIcerikService
    {
        Task<IEnumerable<Icerik>> GetAllIcerik();
        Task<Icerik> GetIcerikById(int id);
        Task<Icerik> CreateIcerik(Icerik newIcerik);
        Task UpdateIcerik(Icerik icerikToBeUpdated, Icerik icerik);
        Task DeleteIcerik(Icerik icerik);
        Task<IEnumerable<Icerik>> GetIcerikByKonuId(int id);
        Task<List<Icerik>> GetIcerikByUserId(string id);
    }
}
