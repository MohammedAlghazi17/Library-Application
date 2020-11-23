namespace LibraryOne.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LibraryOne.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryOne.Models.LibraryModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryOne.Models.LibraryModelContext context)
        {
            var books = new List<Book>
            {
                new Book {Title="Book A", CopiesSold = 144, Publisher = "Text Here", Rating = 1},
                new Book {Title="Book B", CopiesSold = 145, Publisher = "Text Her", Rating = 2},
                new Book {Title="Book C", CopiesSold = 146, Publisher = "Text He", Rating = 3},
                new Book {Title="Book D", CopiesSold = 147, Publisher = "Text H", Rating = 4}


            };
            books.ForEach(b => context.Books.AddOrUpdate(book => book.Title, b));
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author{FirstName="A", LastName="A",
                    Books = books.Where(b=>(b.Title == "Book A") || (b.Title=="Book C")).ToList()},
                new Author{FirstName="B", LastName="B",
                    Books = books.Where(b=>(b.Title == "Book B") || (b.Title=="Book A")).ToList()},
                new Author{FirstName="C", LastName="C",
                    Books = books.Where(b=>(b.Title == "Book D") || (b.Title=="Book C")).ToList()},
                new Author{FirstName="D", LastName="D",
                    Books = books.Where(b=>(b.Title == "Book B") || (b.Title=="Book D")).ToList()}
            };
            authors.ForEach(a => context.Authors.AddOrUpdate(author => author.LastName, a));
            context.SaveChanges();
        }
    }
}
