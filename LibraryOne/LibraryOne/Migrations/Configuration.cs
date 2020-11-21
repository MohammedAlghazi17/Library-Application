namespace LibraryOne.Migrations
{
    using System.Collections.Generic;
    using LibraryOne.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryOne.Models.LibraryModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LibraryOne.Models.LibraryModelContext";

           
        }

        

        protected override void Seed(LibraryOne.Models.LibraryModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.



            var books = new List<Book>
            {
                new Book {Title="The Good Book", CopiesSold=2464, Publisher = "Happy Swamp", Rating=2},
                new Book {Title="The Bad Book", CopiesSold=666, Publisher = "Wobbly Handle", Rating=4},
                new Book {Title="The Ok Book", CopiesSold=246, Publisher = "Angry Frog", Rating=4},
                new Book {Title="The Noisy Book", CopiesSold=26, Publisher = "Ear Today", Rating=6},
                new Book {Title="This is not a Book", CopiesSold=2464, Publisher = "Oada Gone", Rating=1},
            };
            books.ForEach(b => context.Books.AddOrUpdate(Book => Book.Title, b));
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author{FirstName = "AKA", LastName="Noone",
                    Books = books.Where(b => (b.Title =="The Good Book") || (b.Title == "The Bad Book")).ToList() },
                 new Author{FirstName = "J.K.", LastName="Growling",
                    Books = books.Where(b => (b.Title =="The Good Book") || (b.Title == "The Ok Book")).ToList() },

                new Author{FirstName = "A.N", LastName="Other",
                    Books = books.Where(b => (b.Title =="The Noisy Book") || (b.Title == "This is not a Book")).ToList() },
                 new Author{FirstName = "Pu", LastName="Lp",
                    Books = books.Where(b => (b.Title =="The Ok Book") || (b.Title == "The Bad Book")).ToList() },
            };
            authors.ForEach(a => context.Authors.AddOrUpdate(Author => Author.LastName, a));
            context.SaveChanges();
        }
        }
    }
        

