using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labka2.Models;

namespace labka2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly labka2Context _context;

        public BooksController(labka2Context context)
        {
            _context = context;
        }
        public class UserBook : Book
        {
            public string PublishingHouseName { get; set; }
            public UserBook(Book book, string PublishingHouseName)
            {
                this.PublishingHouseName = PublishingHouseName;
                Id = book.Id;
                Year = book.Year;
                Pages = book.Pages;
                PublishingHouseId = book.PublishingHouseId
                    ;
                Name = book.Name;
            }
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBook>>> GetBook(string publishingHouseName)
        {
            var list = _context.Book.Select(c => new UserBook(c, c.PublishingHouse.Name));
            if (publishingHouseName != null)
            {
                var list2 = _context.Book.Where(c => c.PublishingHouse.Name == publishingHouseName)
                    .Select(c => new UserBook(c, c.PublishingHouse.Name));
                return await list2.ToListAsync();
            }
            return await list.ToListAsync();
            //return await _context.Book.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book, string publishingHouseName)
        {
            var publishingHouse = _context.PublishingHouse.Where(l => l.Name == publishingHouseName).FirstOrDefault();
            book.PublishingHouseId = publishingHouse.Id;
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
            //if (id != book.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(book).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BookExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(string[] data)
        {
            PublishingHouse publishingHouse = _context.PublishingHouse.Where(l => l.Name == data[3]).Include(l => l.Books).FirstOrDefault();
            Book book = new Book
            {
                Name = data[0],
                Year = int.Parse(data[1]),
                Pages = int.Parse(data[2]),


                PublishingHouseId = publishingHouse.Id
            };
            book.PublishingHouse = publishingHouse;
            publishingHouse.Books.Add(book);
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
            //    _context.Book.Add(book);
            //    await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}