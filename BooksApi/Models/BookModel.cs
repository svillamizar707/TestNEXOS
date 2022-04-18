using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese el nombre del libro")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese el año del libro")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese el genero del libro")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese el numero de paginas")]
        public int NumPage { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese la editorial")]        
        public int AuthorId { get; set; }
    }
}
