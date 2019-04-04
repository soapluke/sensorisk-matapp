using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity item);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Get(int id);
        TEntity TryGet(int id);
        List<TEntity> GetAll();
        List<TEntity> GetAll<TProperty>(Expression<Func<TEntity, TProperty>> includeExpression);
        //void Reload(TEntity entity);
        //void Reload(IEnumerable entityCollection);
        //List<TEntity> GetAllOrdered<TKey>(Expression<Func<TEntity, TKey>> orderByExpression, bool descending = false);
    }
}
