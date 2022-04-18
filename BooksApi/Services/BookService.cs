using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    using BooksApi.Entities;
    using BooksApi.Interfaces;

    public class BookService : IBookService
    {
        private IBookRepository bookRepository;
        
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book Create(Book book)
        {
            return bookRepository.Create(book);
        }

       /* public async Task Delete(int bookId)
        {
            await bookRepository.Delete(bookId);
        }*/

        public Book GetById(int bookId) => bookRepository.GetById(bookId);

        public IQueryable<Book> GetAllList() => bookRepository.GetAllList();
        

        /*public async Task Update(Book book)
        {
            await bookRepository.Update(book);
        }*/
    }
}
