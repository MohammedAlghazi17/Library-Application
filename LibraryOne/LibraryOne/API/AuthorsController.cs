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
    public class AuthorsController : ApiController
    {
        private LibraryModelContext db = new LibraryModelContext();

        // GET: api/Authors
        public IQueryable<AuthorDTO> GetAuthors()
        {
            var authors = from a in db.Authors
                          select new AuthorDTO()
                          {
                              Id = a.Id,
                              FirstName = a.FirstName,
                              LastName = a.LastName,
                              Books = a.Books.Select(b => new BookDTO()
                              {
                                  Id = b.Id,
                                  Title = b.Title,
                                  Publisher = b.Publisher
                              }).ToList()
                          };


            return authors;
        }

        // GET: api/Authors/5
        [ResponseType(typeof(AuthorDTO))]
        public async Task<IHttpActionResult> GetAuthor(int id)
        {
            Author a = await db.Authors.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }
            AuthorDTO author = new AuthorDTO
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Books = a.Books.Select(b => new BookDTO()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Publisher = b.Publisher

                }).ToList()
            };
            return Ok(author);
        }

       

                // PUT: api/Authors/5
                [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.Id)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public IHttpActionResult PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(author);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult DeleteAuthor(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            db.Authors.Remove(author);
            db.SaveChanges();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorExists(int id)
        {
            return db.Authors.Count(e => e.Id == id) > 0;
        }
    }
}