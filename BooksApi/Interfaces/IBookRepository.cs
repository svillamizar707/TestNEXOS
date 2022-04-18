using BooksApi.Interfaces.Base;

namespace BooksApi.Interfaces
{
    using BooksApi.Entities;

    public interface IBookRepository : IRepository<Book>
    {
    }
}
