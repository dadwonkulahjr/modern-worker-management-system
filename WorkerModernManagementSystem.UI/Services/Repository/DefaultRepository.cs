using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WorkerModernManagementSystem.UI.Services.IRepository;

namespace WorkerModernManagementSystem.UI.Services.Repository
{
    public class DefaultRepository<T> : IDefaultRepository<T> where T : class
    {
        protected internal DbContext _dbContext;
        internal DbSet<T> _dbSet;
        public DefaultRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void AddNewEntityType(T entityTypeToAdd)
        {
            _dbSet.Add(entityTypeToAdd);
        }
        public IEnumerable<T> GetEntityTypeAll(Expression<Func<T, bool>> fiterEntityType = null, string entityNavigationProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>> sortEntityType = null)
        {
            IQueryable<T> myQuery = _dbSet;

            if(fiterEntityType != null)
            {
                myQuery = myQuery.Where(fiterEntityType);
            }

            if(entityNavigationProperties != null)
            {
                foreach (var property in entityNavigationProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    myQuery.Include(property);
                }
            }

            if(sortEntityType != null)
            {
                return sortEntityType(myQuery).ToList();
            }

            return myQuery.ToList();
        }
        public T GetFirstOrDefaultEntityType(Expression<Func<T, bool>> fiterEntityType = null, string entityNavigationProperties = null)
        {
            IQueryable<T> myQuery = _dbSet;

            if (fiterEntityType != null)
            {
                myQuery = myQuery.Where(fiterEntityType);
            }

            if (entityNavigationProperties != null)
            {
                foreach (var property in entityNavigationProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    myQuery.Include(property);
                }
            }

            return myQuery.FirstOrDefault();
        }
        public T GetType(int id)
        {
            return GetType(id);
        }
        public T GetType(T entityTypeId)
        {
            return _dbSet.Find(entityTypeId);
        }

        public void Remove(T entityTypeToRemove)
        {
            _dbSet.Remove(entityTypeToRemove);
        }

        public void Remove(int entityTypeToRemoveId)
        {
            Remove(entityTypeToRemoveId);
        }
    }
}
