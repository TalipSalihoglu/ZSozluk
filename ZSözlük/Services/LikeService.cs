using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Contexts;
using ZSözlük.IRepositories;
using ZSözlük.IServices;
using ZSözlük.Models;

namespace ZSözlük.Services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Like(int id, string _userid)
        {
            LikeModel m = new LikeModel();
            m.IcerikID = id;
            m.UserID = _userid;
            await _unitOfWork.Likes.AddAsync(m);
            await _unitOfWork.CommitAsync();
            return id;
        }
        public async Task<int> CancelLike(int id, string _userid)
        {
            var kk = _unitOfWork.Likes.GetAllAsync().Result.Where(x => x.IcerikID == id && x.UserID == _userid).FirstOrDefault();
            _unitOfWork.Likes.Remove(kk);
            await _unitOfWork.CommitAsync();
            return id;
        }

        public int CountOfLike(int id)
        {
            return _unitOfWork.Likes.GetAllAsync().Result.Where(x => x.IcerikID == id).Count();
        }

        public bool isLike(int id, string _userid)
        {
            var urun = _unitOfWork.Icerikler.GetByIdAsync(id);
            var userid = _userid;
            if (_unitOfWork.Likes.GetAllAsync().Result.Where(x => x.UserID == userid && x.IcerikID == id).Count() == 0)
                return false;
            return true;
        }

       
    }
}
