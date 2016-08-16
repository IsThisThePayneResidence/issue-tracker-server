using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using It.Model.Domain;

namespace It.Model.Interfaces
{
    public interface IRepository<T> 
        where T : Entity
    {
        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        ICollection<T> SearchFor(Func<T, bool> predicate);

        ICollection<T> GetAll();

        T GetById(Guid id);
    }
}
