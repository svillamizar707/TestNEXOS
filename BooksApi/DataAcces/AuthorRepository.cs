using BooksApi.DataAcces;
using BooksApi.Entities;
using BooksApi.Interfaces;
using Oracle.ManagedDataAccess.EntityFramework;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.DataAcces
{
    public class AuthorRepository : IAuthorRepository
    {
        private BooksApiContext context;

        public AuthorRepository(BooksApiContext ctx)
        {
            context = ctx;
        }

        public Author Create(Author entity)
        {
            if (entity.Id == 0)
            {
                context.Authors.Add(entity);
            }

            context.SaveChanges();

            return entity;
        }

        public async Task Delete(int id)
        {
            Author dbEntry = context.Authors
                .FirstOrDefault(b => b.Id == id);
            if (dbEntry != null)
            {
                context.Authors.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
        }

        public IQueryable<Author> GetAllList() => context.Authors.AsQueryable();

        public Author GetById(int id) => context.Authors.FirstOrDefault(x => x.Id == id);

        /*public async Task Update(Author entity)
        {
            if (entity.Id > 0)
            {
                Author dbEntry = context.Authors
                    .FirstOrDefault(a => a.Id == entity.Id);
                if (dbEntry != null)
                {
                    dbEntry.FullName = entity.FullName;
                    dbEntry.BirthDate = entity.BirthDate;
                    dbEntry.HomeCity = entity.HomeCity;
                    dbEntry.Email = entity.Email;
                }
            }

            await context.SaveChangesAsync();
        }*/
    }
}
