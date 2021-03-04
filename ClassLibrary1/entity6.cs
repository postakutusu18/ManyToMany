using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{

    public class Book2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsbnNo { get; set; }

        public ICollection<BookAuthor2> BookAuthors2 { get; set; }

        public Book2()
        {
            BookAuthors2 = new HashSet<BookAuthor2>();
        }
    }


    public class Author2
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }

        public ICollection<BookAuthor2> BookAuthors2 { get; set; }

        public Author2()
        {
            BookAuthors2 = new HashSet<BookAuthor2>();
        }
    }
    public class BookAuthor2
    {
        public string IdentityNumber { get; set; }
        public string IsbnNo { get; set; }

        public Book2 Book2 { get; set; }
        public Author2 Author2 { get; set; }

    }

}
