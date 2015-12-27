using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IRepository<T> : IDisposable
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
        void SaveChanges();
        T GetByMyQuery(Expression<Func<T, bool>> lamdaExpression);
    }
}
