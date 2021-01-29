using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.IServices
{
    public interface ILikeService
    {
        Task<int> Like(int id, string _userid);
        public Task<int> CancelLike(int id, string _userid);
        public bool isLike(int id, string _userid);
        public int CountOfLike(int id);
    }
}
