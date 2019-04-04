using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Entities;
using Data.Repositories.Interfaces;


namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected UnitOfWork UnitOfWork
        {
            get
            {
                return (UnitOfWork)_unitOfWork;
            }
        }

        protected DbSet<TEntity> Items
        {
            get
            {
                return UnitOfWork.Context.Set<TEntity>();
            }
        }

        public virtual TEntity Add(TEntity item)
        {
            var savedItem = Items.Add(item);
            _unitOfWork.SaveChanges();
            return savedItem.Entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            //Items.AddRange(entities);
            var savedItems = new List<TEntity>();
            foreach(var item in entities)
            {
                savedItems.Add(Add(item));
            }
            _unitOfWork.SaveChanges();
            return savedItems;
        }

        public virtual TEntity Remove(TEntity item)
        {
            return Items.Remove(item).Entity;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Items.RemoveRange(entities);
        }

        public virtual TEntity Get(int id)
        {
            var entity = Items.Find(id);

            if (entity == null)
            {
                throw new Exception("The entity does not exist, id: " + id + ", type:" + typeof(TEntity).Name);
            }

            return entity;
        }

        public virtual TEntity TryGet(int id)
        {
            return Items.Find(id);
        }

        public virtual List<TEntity> GetAll<TProperty>(Expression<Func<TEntity, TProperty>> includeExpression)
        {
            return Items
                .Include(includeExpression)
                .ToList();
        }

        public virtual List<TEntity> GetAll()
        {
            return Items
                .ToList();
        }

        //public virtual List<TEntity> GetAllOrdered<TKey>(Expression<Func<TEntity, TKey>> orderByExpression, bool descending = false)
        //{
        //    return descending ? Items.OrderByDescending(orderByExpression).ToList() : Items.OrderBy(orderByExpression).ToList();
        //}

        //public void Reload(TEntity entity)
        //{
        //    UnitOfWork.Context.Entry(entity).Reload();
        //}

        //public void Reload(IEnumerable entityCollection)
        //{
        //    var adapter = (IObjectContextAdapter)UnitOfWork.Context;
        //    ObjectContext objectContext = adapter.ObjectContext;
        //    objectContext.Refresh(RefreshMode.StoreWins, entityCollection);
        //}

    }
}
