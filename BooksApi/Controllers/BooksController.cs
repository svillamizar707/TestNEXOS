using System.Linq;
using System.Web.Http;
using BooksApi.Models;
using BooksApi.Interfaces;

namespace BooksApi.Controllers
{   

    using BooksApi.Entities; 

    [RoutePrefix("api/[controller]")]
    public class BooksController : ApiController
    {      
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService, IAuthorService authorService)
        {           
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] BookModel model)
        {
            if (model == null)
            {
                return BadRequest("Peticion no valida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var author = _authorService.GetById(model.AuthorId);


                if (author == null)
                {
                    return BadRequest("El autor no está registrado");
                }

                var authorBooksCount = _bookService.GetAllList().Where(b => b.AuthorId == model.AuthorId).Count();

                var allowCreateBook = author.BooksLimit > authorBooksCount ? true : false;

                if (allowCreateBook)
                {
                    var book = Book.Create(model.Title, model.Year, model.Gender, model.NumPage, model.AuthorId);

                    _bookService.Create(book);

                    return CreatedAtRoute("GetBook", new { id = book.Id }, book);
                }
                else
                {
                    return BadRequest("No es posible registrar el libro, se alcanzó el máximo permitido");
                }
            }
        }

        [Route("Search")]
        [AcceptVerbs("GET")]
        [HttpGet]       
        public IHttpActionResult Search(BooksSearchFilter filter)
        {
            var data = _bookService.GetAllList();

            if (!string.IsNullOrEmpty(filter.Title))
                data = data.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower()));

            if (!string.IsNullOrEmpty(filter.Author))
                data = data.Where(x => x.Author.FullName.ToLower().Contains(filter.Author.ToLower()));

            if (filter.Year != null)
                data = data.Where(x => x.Year.ToString() == filter.Year);

            return Ok(data.Select(x => new { x.Id, x.Title, x.Gender, x.Year, x.NumPages, x.AuthorId, AuthorName = x.Author.FullName }));
        }
        
        
        [AcceptVerbs("GET")]
        [HttpGet]
        //[Route("GetBook")]
        public IHttpActionResult GetBook(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return BadRequest("El libro no está registrado");
            }

            return Ok(new { book.Id, book.Title, book.Gender, book.Year, book.NumPages, book.AuthorId });
        }   
        
    }
}
