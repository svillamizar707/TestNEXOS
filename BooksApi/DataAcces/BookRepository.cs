using BooksApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BooksApi.Data
{
    using BooksApi.DataAcces;
    using BooksApi.Entities;
    using Oracle.ManagedDataAccess.Client;
    using System.Configuration;
    using System.Data.Entity.Core.EntityClient;

    public class BookRepository : IBookRepository
    {
        //private BooksApiContext context = new BooksApiContext();

        private BooksApiContext _context;

        public BookRepository(BooksApiContext dbcontex)
        {
            _context = dbcontex;
        }

        public Book Create(Book entity)
        {
            if (entity.Id == 0)
            {
                _context.Books.Add(entity);
            }

            _context.SaveChanges();

            return entity;
        }

        /*public async Task Delete(int id)
        {
            Book dbEntry = context.Books
                .FirstOrDefault(b => b.Id == id);
            if (dbEntry != null)
            {
                context.Books.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
        }*/

        public IQueryable<Book> GetAllList() => _context.Books.AsQueryable();

        public Book GetById(int id) {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public async Task Update(Book entity)
        {
            if (entity.Id > 0)
            {
                Book dbEntry = _context.Books
                    .FirstOrDefault(b => b.Id == entity.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = entity.Title;
                    dbEntry.Year = entity.Year;
                    dbEntry.Gender = entity.Gender;
                    dbEntry.NumPages = entity.NumPages;               
                    dbEntry.AuthorId = entity.AuthorId;
                }
            }

           await _context.SaveChangesAsync();
        }
    }
}
