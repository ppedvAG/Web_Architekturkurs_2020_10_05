using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly ClubDBContext _context;

        //public ClubController()
        //{
        //    _context = new ClubDBContext();
        //}

        public ClubController(ClubDBContext context)
        {
            _context = context;
        }

        // GET: api/Club -> https/localhost/12345/api/Club

        //Get: api/Club
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clubs>>> GetClubs()
        {
            return await _context.Clubs.ToListAsync();
        }

        // GET: api/Club/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clubs>> GetClubs(int id)
        {
            var clubs = await _context.Clubs.FindAsync(id);

            if (clubs == null)
            {
                return NotFound();
            }

            return clubs;
        }

        // PUT: api/Club/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClubs(int id, Clubs clubs)
        {
            if (id != clubs.Id)
            {
                return BadRequest();
            }

            _context.Entry(clubs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubsExists(id))
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

        // POST: api/Club
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clubs>> PostClubs(Clubs clubs)
        {
            _context.Clubs.Add(clubs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClubs", new { id = clubs.Id }, clubs);
        }

        // DELETE: api/Club/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clubs>> DeleteClubs(int id)
        {
            var clubs = await _context.Clubs.FindAsync(id);
            if (clubs == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(clubs);
            await _context.SaveChangesAsync();

            return clubs;
        }

        private bool ClubsExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}
