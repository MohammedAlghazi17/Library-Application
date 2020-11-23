using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Models
{
    public class Author
    {
        private ICollection<Book> _books;

        public Author()
        {
            _books = new List<Book>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }
    }
}