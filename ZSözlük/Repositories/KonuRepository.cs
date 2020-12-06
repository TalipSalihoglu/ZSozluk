﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Contexts;
using ZSözlük.Entities;
using ZSözlük.IRepositories;

namespace ZSözlük.Repositories
{
    public class KonuRepository : Repository<Konu>,IKonuRepository
    {
        public KonuRepository(ZSozlukContext zSozlukContext) : base(zSozlukContext)
        {

        }
    }
}
