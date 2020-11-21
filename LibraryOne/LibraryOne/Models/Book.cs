using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryOne.Models
{
    public class Book
    {
        private ICollection<Author> _authors;


        public Book()
        {
            _authors = new List<Author>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Rating { get; set; }
        public int CopiesSold { get; set; }

        public virtual ICollection<Author> Authors

        {
            get { return _authors; }
            set { _authors = value; }
        }

    }
}