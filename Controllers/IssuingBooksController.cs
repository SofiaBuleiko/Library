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
    public class IssuingBooksController : ControllerBase
    {
        private readonly labka2Context _context;

        public IssuingBooksController(labka2Context context)
        {
            _context = context;
        }

        // GET: api/IssuingBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssuingBooks>>> GetIssuingBooks()
        {
            return await _context.IssuingBooks.ToListAsync();
        }

        // GET: api/IssuingBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IssuingBooks>> GetIssuingBooks(int id)
        {
            var issuingBooks = await _context.IssuingBooks.FindAsync(id);

            if (issuingBooks == null)
            {
                return NotFound();
            }

            return issuingBooks;
        }

        // PUT: api/IssuingBooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssuingBooks(int id, IssuingBooks issuingBooks)
        {
            if (id != issuingBooks.Id)
            {
                return BadRequest();
            }

            _context.Entry(issuingBooks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuingBooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IssuingBooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IssuingBooks>> PostIssuingBooks(IssuingBooks issuingBooks)
        {
            _context.IssuingBooks.Add(issuingBooks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssuingBooks", new { id = issuingBooks.Id }, issuingBooks);
        }

        // DELETE: api/IssuingBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IssuingBooks>> DeleteIssuingBooks(int id)
        {
            var issuingBooks = await _context.IssuingBooks.FindAsync(id);
            if (issuingBooks == null)
            {
                return NotFound();
            }

            _context.IssuingBooks.Remove(issuingBooks);
            await _context.SaveChangesAsync();

            return issuingBooks;
        }

        private bool IssuingBooksExists(int id)
        {
            return _context.IssuingBooks.Any(e => e.Id == id);
        }
    }
}
