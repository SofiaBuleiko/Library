﻿using System;
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
    public class LecturersController : ControllerBase
    {
        private readonly labka2Context _context;

        public LecturersController(labka2Context context)
        {
            _context = context;
        }

        // GET: api/Lecturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lecturer>>> GetLecturer()
        {
            return await _context.Lecturer.ToListAsync();
        }

        // GET: api/Lecturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecturer>> GetLecturer(int id)
        {
            var lecturer = await _context.Lecturer.FindAsync(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            return lecturer;
        }

        // PUT: api/Lecturers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecturer(int id, Lecturer lecturer)
        {
            if (id != lecturer.Id)
            {
                return BadRequest();
            }

            _context.Entry(lecturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
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

        // POST: api/Lecturers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lecturer>> PostLecturer(Lecturer lecturer)
        {
            _context.Lecturer.Add(lecturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLecturer", new { id = lecturer.Id }, lecturer);
        }

        // DELETE: api/Lecturers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lecturer>> DeleteLecturer(int id)
        {
            var lecturer = await _context.Lecturer.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            _context.Lecturer.Remove(lecturer);
            await _context.SaveChangesAsync();

            return lecturer;
        }

        private bool LecturerExists(int id)
        {
            return _context.Lecturer.Any(e => e.Id == id);
        }
    }
}
