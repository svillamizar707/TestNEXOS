using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese el nombre completo del autor")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese la fecha de cumpleanos del autor")]
        public string BirthDate { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese la ciudad de origen del autor")]
        public string HomeCity { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese el correo electronico del autor")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el máximo de libros")]
        public string BooksLimit { get; set; }
    }
}
