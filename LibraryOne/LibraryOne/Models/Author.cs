using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryOne.Models
{
    public class Author
    {
        private ICollection<Book> _books;

        public Author ()
        {
            _books = new List<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }
    }


}