using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryOne.Models;
using LibraryWebApp.Models;

namespace LibraryOne.API
{
    public class BooksController : ApiController
    {
        private LibraryModelContext db = new LibraryModelContext();

        // GET: api/Books
        public IQueryable<BookDTO> GetBooks()
        {
            var books = from b in db.Books
                        select new BookDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            CopiesSold = b.CopiesSold,
                            Publisher = b.Publisher,
                            Rating = b.Rating,
                            Authors = b.Authors.Select(a => new AuthorDTO()
                            {
                                Id = a.Id,
                                FirstName = a.FirstName,
                                LastName = a.LastName
                            }).ToList()

                        };



            return books;
        }



        // GET: api/Books/5
        [ResponseType(typeof(BookDTO))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Book b = await db.Books.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            BookDTO book = new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                CopiesSold = b.CopiesSold,
                Publisher = b.Publisher,
                Rating = b.Rating,
                Authors = b.Authors.Select(a => new AuthorDTO()
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }).ToList()


            };
            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}