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
    public class PublishingHousesController : ControllerBase
    {
        private readonly labka2Context _context;

        public PublishingHousesController(labka2Context context)
        {
            _context = context;
        }

        // GET: api/PublishingHouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublishingHouse>>> GetPublishingHouse()
        {
            return await _context.PublishingHouse.ToListAsync();
        }

        // GET: api/PublishingHouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublishingHouse>> GetPublishingHouse(int id)
        {
            var publishingHouse = await _context.PublishingHouse.FindAsync(id);

            if (publishingHouse == null)
            {
                return NotFound();
            }

            return publishingHouse;
        }

        // PUT: api/PublishingHouses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishingHouse(int id, PublishingHouse publishingHouse)
        {
            if (id != publishingHouse.Id)
            {
                return BadRequest();
            }

            _context.Entry(publishingHouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishingHouseExists(id))
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

        // POST: api/PublishingHouses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PublishingHouse>> PostPublishingHouse(PublishingHouse publishingHouse)
        {
            _context.PublishingHouse.Add(publishingHouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublishingHouse", new { id = publishingHouse.Id }, publishingHouse);
        }

        // DELETE: api/PublishingHouses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublishingHouse>> DeletePublishingHouse(int id)
        {
            var publishingHouse = await _context.PublishingHouse.FindAsync(id);
            if (publishingHouse == null)
            {
                return NotFound();
            }

            _context.PublishingHouse.Remove(publishingHouse);
            await _context.SaveChangesAsync();

            return publishingHouse;
        }

        private bool PublishingHouseExists(int id)
        {
            return _context.PublishingHouse.Any(e => e.Id == id);
        }
    }
}
