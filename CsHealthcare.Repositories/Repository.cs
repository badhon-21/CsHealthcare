using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CsHealthcare.DataAccess;
using CsHealthcare.RepositoriesInterface;

namespace CsHealthcare.Repositories
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        public readonly AppDbContext _appsDbContext;


        protected Repository(AppDbContext context)
        {
            _appsDbContext = context;

        }

        public void DisableLazyLoading()
        {
            _appsDbContext.Configuration.LazyLoadingEnabled = false;
        }
        public void EnabledLazyLoading()
        {
            _appsDbContext.Configuration.LazyLoadingEnabled = true;
        }
        /// <summary>
        /// Get All value Of table 
        /// </summary>
        /// <returns>List of table objet </returns>
        public virtual List<T> Get()
        {
            return _appsDbContext.Set<T>().ToList();
        }

        /// <summary>
        /// Get selected object value 
        /// </summary>
        /// <param name="id">Intiger Type Primary key for search </param>
        /// <returns>Table object</returns>
        public virtual T Get(int id)
        {
            return _appsDbContext.Set<T>().Find(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(string id)
        {
            return _appsDbContext.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> GetData(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = _appsDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Update(T obj)
        {
            _appsDbContext.Entry(obj).State = EntityState.Modified;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Insert(T obj)
        {
            return _appsDbContext.Set<T>().Add(obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Delete(T obj)
        {
            return _appsDbContext.Set<T>().Remove(obj);
        }

        public virtual T DeleteById(int id)
        {
            var obj = Get(id);
            return Delete(obj);
        }

        public virtual T DeleteById(string id)
        {
            var obj = Get(id);
            return Delete(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Edit(T obj)
        {
            _appsDbContext.Entry(obj).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _appsDbContext.Set<T>().Where(predicate); ;
        }

        public void Save()
        {
            _appsDbContext.SaveChanges();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // _appsDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
