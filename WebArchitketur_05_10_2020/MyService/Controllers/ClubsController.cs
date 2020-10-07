using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDomain.Entities;


namespace MyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IRepository<Clubs> repository;

        public ClubsController(IRepository<Clubs> _repo)
        {
            repository = _repo;
        }

        // GET: api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clubs>>> GetClubs()
        {

            return await repository.GetAll();
        }

        

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public  async Task<ActionResult<Clubs>> GetClubs(int id)
        {
            //var clubs = await _context.Clubs.FindAsync(id);

            Clubs clubs = await repository.Single(c => c.Id == id);

            // Komplexe Berechnung (Aus mehreren Tabellen Zwischen-Ergebnisse(Parameter meiner Berechnung) heraus lesen) + Das Endergebnis wird als Service - Rückgabewerte zurückgegeben.
             
            //...30-40 Zeilen Code Berechnung

            if (clubs == null)
            {
                return NotFound();
            }

            return clubs;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public  async Task<IActionResult> PutClubs(int id, Clubs clubs)
        {
            if (id != clubs.Id)
            {
                return BadRequest();
            }

            await repository.Update(clubs);

            return NoContent();
        }

        // POST: api/Clubs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clubs>> PostClubs(Clubs clubs)
        {
            await repository.Insert(clubs);
            return CreatedAtAction("GetClubs", new { id = clubs.Id }, clubs);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clubs>> DeleteClubs(int id)
        {
            var club = await repository.Single(c => c.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            await repository.Delete(club);
            return club;
        }

       
    }
}
