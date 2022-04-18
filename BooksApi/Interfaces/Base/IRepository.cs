using BooksApi.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BooksApi.Interfaces.Base
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAllList();
        T GetById(int id);
        T Create(T entity);
        /*Task Update(T entity);
        Task Delete(int id);*/
    }
}
