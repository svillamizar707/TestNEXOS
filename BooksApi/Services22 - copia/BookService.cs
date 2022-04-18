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

        public async Task<Book> Create(Book book)
        {
            return await bookRepository.Create(book);
        }

        public async Task Delete(decimal bookId)
        {
            await bookRepository.Delete(bookId);
        }

        public async Task<Book> GetById(decimal bookId) => await bookRepository.GetById(bookId);

        public IQueryable<Book> GetAllList() => bookRepository.GetAllList();
        

        public async Task Update(Book book)
        {
            await bookRepository.Update(book);
        }
    }
}
