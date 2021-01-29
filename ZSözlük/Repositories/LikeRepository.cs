using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Contexts;
using ZSözlük.IRepositories;
using ZSözlük.Models;

namespace ZSözlük.Repositories
{
    public class LikeRepository : Repository<LikeModel>, ILikeRepository
    {
        public LikeRepository(ZSozlukContext zSozlukContext) : base(zSozlukContext)
        {

        }
    }
}
