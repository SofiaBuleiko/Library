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
    public class ReadersController : ControllerBase
    {
        private readonly labka2Context _context;

        public ReadersController(labka2Context context)
        {
            _context = context;
        }

        // GET: api/Readers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reader>>> GetReader()
        {
            return await _context.Reader.ToListAsync();
        }

        // GET: api/Readers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reader>> GetReader(int id)
        {
            var reader = await _context.Reader.FindAsync(id);

            if (reader == null)
            {
                return NotFound();
            }

            return reader;
        }

        // PUT: api/Readers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReader(int id, Reader reader)
        {
            if (id != reader.Id)
            {
                return BadRequest();
            }

            _context.Entry(reader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderExists(id))
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

        // POST: api/Readers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reader>> PostReader(Reader reader)
        {
            _context.Reader.Add(reader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReader", new { id = reader.Id }, reader);
        }

        // DELETE: api/Readers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reader>> DeleteReader(int id)
        {
            var reader = await _context.Reader.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }

            _context.Reader.Remove(reader);
            await _context.SaveChangesAsync();

            return reader;
        }

        private bool ReaderExists(int id)
        {
            return _context.Reader.Any(e => e.Id == id);
        }
    }
}
