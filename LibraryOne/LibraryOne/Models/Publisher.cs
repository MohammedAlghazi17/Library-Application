using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryOne.Models
{
    public class Publisher
    {
        private ICollection<Book> _books;

        public Publisher()
        {
            _books = new List<Book>();
        }

        public int PublisherId { get; set; }

        public string Name { get; set; }
        public DateTime Established { get; set; }

        public virtual ICollection<Book> Books

        {
            get { return _books; }
            set { _books = value; }
        }
    }
}