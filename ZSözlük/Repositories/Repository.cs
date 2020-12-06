using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZSözlük.IRepositories;

namespace ZSözlük.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
       
        private readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }
    
        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync() /// async await !!
        {
            return await Context.Set<T>().ToListAsync();
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        //public IQueryable<T> GetAll()
        //{
        //    return  Context.Set<TEntity>().ToList();
        //}

        //public IQueryable<T> GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
