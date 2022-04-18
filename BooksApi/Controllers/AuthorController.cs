using BooksApi.Entities;
using BooksApi.Models;
using BooksApi.Interfaces;
using System;
using System.Linq;
using System.Web.Http;

namespace Book.Api.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class AuthorController : ApiController
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = authorService.GetAllList().OrderBy(a => a.Id);

            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = authorService.GetById(id);
            if (author == null)
            {                
                return BadRequest("El autor no está registrado");
            }

            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult Post(AuthorModel model)
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
                DateTime dateOfBirth;
                if (!DateTime.TryParse(model.BirthDate, out dateOfBirth))
                {
                    return BadRequest("La fecha ingresada no es valida");
                }

                var author = Author.Create(0, model.FullName, dateOfBirth, model.HomeCity, model.Email);                

                authorService.Create(author);

                return CreatedAtRoute("GetAuthor", new { id = author.Id }, author);
            }
        }        
    }
}
