using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LibraryWebApp.Models
{
    public class LibraryContext : DbContext
    {

        public LibraryContext() : base("LibraryContext") { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}