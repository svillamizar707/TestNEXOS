using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    using BooksApi.Entities;
    using BooksApi.Interfaces;

    public class AuthorService : IAuthorService
    {
        private IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Author> Create(Author author)
        {
            return await authorRepository.Create(author);
        }

        public async Task Delete(decimal authorId)
        {
            await authorRepository.Delete(authorId);
        }

        public async Task<Author> GetById(decimal authorId) => await authorRepository.GetById(authorId);

        public IQueryable<Author> GetAllList() => authorRepository.GetAllList();

        public async Task Update(Author author)
        {
            await authorRepository.Update(author);
        }
    }
}
