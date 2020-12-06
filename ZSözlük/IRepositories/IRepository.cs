using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZSözlük.IRepositories
{
    public interface IRepository<T> where T :class
    {
        //IQueryable<T> GetById(int id);
        //IQueryable<T> GetAll();
        ValueTask<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        
        Task AddAsync(T entity);
           
        void Remove(T entity);
    }
}
