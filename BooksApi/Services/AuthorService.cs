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

        public Author Create(Author author)
        {
            return authorRepository.Create(author);
        }

        /*public async Task Delete(int authorId)
        {
            authorRepository.Delete(authorId);
        }*/

        public Author GetById(int authorId) => authorRepository.GetById(authorId);

        public IQueryable<Author> GetAllList() => authorRepository.GetAllList();

       /* publicUpdate(Author author)
        {
            authorRepository.Update(author);
        }*/
    }
}
