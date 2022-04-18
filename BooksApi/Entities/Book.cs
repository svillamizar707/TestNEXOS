using BooksApi.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BooksApi.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("BOOKS")]
    public class Book : Entity
    {
        [Required]
        [Column("TITLE")]
        public string Title { get; set; }
        [Required]
        [Column("YEAR")]
        public int Year { get; set; }
        [Required]
        [Column("GENDER")]
        public string Gender { get; set; }
        [Required]
        [Column("NUMPAGES")]
        public int NumPages { get; set; }
       
        [Required]
        [Column("AUTHORID")]
        public int AuthorId { get; set; }
        [JsonIgnore]
        public virtual Author Author { get; set; }

        public static Book Create(string title, int year, string gender, int numPages, int authorId)
        {
            return new Book
            {               
                Title = title,
                Year = year,
                Gender = gender,
                NumPages = numPages,
                AuthorId = authorId
            };
        }
    }
}
