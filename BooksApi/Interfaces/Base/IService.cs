using System.Linq;

namespace BooksApi.Interfaces.Base
{
    using BooksApi.Entities.Base;
    using System.Threading.Tasks;

    public interface IService<T> where T : Entity
    {
        IQueryable<T> GetAllList();
        T GetById(int id);
        T Create(T entity);
        /*Update(T entity);
        Delete(int id);*/
       
    }
}
