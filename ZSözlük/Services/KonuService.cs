using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Entities;
using ZSözlük.IRepositories;

namespace ZSözlük.Services
{
    public class KonuService : IKonuService
    {
        private readonly IUnitOfWork _unitOfWork;
        public KonuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Konu> CreateKonu(Konu newKonu)
        {
            await _unitOfWork.Konular.AddAsync(newKonu);
            await _unitOfWork.CommitAsync();
            return newKonu;
        }

        public async Task DeleteKonu(Konu konu)
        {
            _unitOfWork.Konular.Remove(konu);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Konu>> GetAllKonu()
        {
           return await _unitOfWork.Konular.GetAllAsync();
        }

        public async Task<Konu> GetKonuById(int id)
        {
            return await _unitOfWork.Konular.GetByIdAsync(id);
        }

        public async Task UpdateKonu(Konu konuToBeUpdated, Konu konu) // ????
        {
            konuToBeUpdated.KonuBaslık = konu.KonuBaslık;
            konuToBeUpdated.KonuID = konu.KonuID;
            konuToBeUpdated.Icerikler = konu.Icerikler;

            await _unitOfWork.CommitAsync();
        }
    }
}
