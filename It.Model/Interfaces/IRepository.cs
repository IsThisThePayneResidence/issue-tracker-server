using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Interfaces
{
    public interface IRepository<T> 
        where T : IEntity
    {
        void Insert(T entity);

        void Delete(T entity);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        T GetById(Guid id);
    }
}
