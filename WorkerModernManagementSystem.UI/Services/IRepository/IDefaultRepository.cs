using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WorkerModernManagementSystem.UI.Services.IRepository
{
    public interface IDefaultRepository<TEntityType> where TEntityType : class
    {
        TEntityType GetType(int id);
        TEntityType GetType(TEntityType entityTypeId);
        IEnumerable<TEntityType> GetEntityTypeAll(Expression<Func<TEntityType, bool>> fiterEntityType = null,
            string entityNavigationProperties = null, Func<IQueryable<TEntityType>, IOrderedQueryable<TEntityType>> sortEntityType = null);
        TEntityType GetFirstOrDefaultEntityType(Expression<Func<TEntityType, bool>> fiterEntityType = null,
            string entityNavigationProperties = null);

        void AddNewEntityType(TEntityType entityTypeToAdd);
        void Remove(TEntityType entityTypeToRemove);
        void Remove(int entityTypeToRemoveId);
    }
}
