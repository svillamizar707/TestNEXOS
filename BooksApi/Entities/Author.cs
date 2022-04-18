using BooksApi.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BooksApi.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("AUTHOR")]
    public class Author : Entity
    {
        [Required]
        [Column("FULLNAME")]
        public string FullName { get; set; }
        [Required]
        [Column("BIRTHDATE")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Column("HOMECITY")]
        public string HomeCity { get; set; }
        [Required]
        [Column("EMAIL")]
        public string Email { get; set; }
        [Required]
        [Column("BOOKSLIMIT")]
        public int BooksLimit { get; set; }
        [JsonIgnore]
        public virtual List<Book> Books { get; set; }

        public static Author Create(int authorId, string fullName, DateTime birthDate, string homeCity, string email)
        {
            return new Author
            {
                Id = authorId,
                FullName = fullName,
                BirthDate = birthDate,
                HomeCity = homeCity,
                Email = email,
            };
        }
    }
}
