using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TestRepository<T> : IRepository<T> where T : class
    {
        private DbSet<T> DatabaseSet;
        private RepositoryPaterrnTestContext repositoryPaterrnTestContext;

        public TestRepository(RepositoryPaterrnTestContext databaseContext)
        {
            repositoryPaterrnTestContext = databaseContext;
            DatabaseSet = databaseContext.Set<T>();
        }


        public void Insert(T entity)
        {
            DatabaseSet.Add(entity);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            DatabaseSet.Remove(entity);
            SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return DatabaseSet;
        }

        public T GetById(int id)
        {
            return DatabaseSet.Find(id);
        }

        public void SaveChanges()
        {
            repositoryPaterrnTestContext.SaveChanges();
        }

        public T GetByMyQuery(Expression<Func<T, bool>> lamdaExpression)
        {
            return DatabaseSet.Where(lamdaExpression).FirstOrDefault();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
