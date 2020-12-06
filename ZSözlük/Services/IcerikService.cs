using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Entities;
using ZSözlük.IRepositories;

namespace ZSözlük.Services
{
    public class IcerikService : IIcerikService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IcerikService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Icerik> CreateIcerik(Icerik newIcerik)
        {
            await _unitOfWork.Icerikler.AddAsync(newIcerik);
            await _unitOfWork.CommitAsync();
            return newIcerik;
        }

        public async Task DeleteIcerik(Icerik icerik)
        {
            _unitOfWork.Icerikler.Remove(icerik);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Icerik>> GetAllIcerik()
        {
            var list =await _unitOfWork.Icerikler.GetAllAsync();
            return list.OrderByDescending(I => I.IcerikID);
        }

        public async Task<Icerik> GetIcerikById(int id)
        {
            return await _unitOfWork.Icerikler.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Icerik>> GetIcerikByKonuId(int id)
        {
             var list =await _unitOfWork.Icerikler.GetAllAsync();
             return  list.Where(i => i.KonuID == id).OrderByDescending(I => I.IcerikID);//ToListAsync();         
        }

        public async Task UpdateIcerik(Icerik icerikToBeUpdated, Icerik icerik) // ???
        {
            icerikToBeUpdated.IcerikFull = icerik.IcerikFull;
            icerikToBeUpdated.KonuID = icerik.KonuID;

            await _unitOfWork.CommitAsync();
        }

    }
}
