using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CsHealthcare.RepositoriesInterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> Get();
        TEntity Get(int id);
        TEntity Get(string id);
        IEnumerable<TEntity> GetData(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void Update(TEntity obj);
        TEntity Insert(TEntity obj);
        TEntity Delete(TEntity obj);
        TEntity DeleteById(int id);
        TEntity DeleteById(string id);
        void Edit(TEntity obj);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Save();
    }
}
