using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.DataLayer.AngularJsForNetCourse
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
