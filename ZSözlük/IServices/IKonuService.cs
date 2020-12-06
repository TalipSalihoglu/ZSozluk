using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Entities;

namespace ZSözlük.Services
{
    public interface IKonuService
    {
        Task<IEnumerable<Konu>> GetAllKonu();
        Task<Konu> GetKonuById(int id);
        Task<Konu> CreateKonu(Konu newKonu);
        Task UpdateKonu(Konu konuToBeUpdated, Konu konu);
        Task DeleteKonu(Konu konu);
    }
}
