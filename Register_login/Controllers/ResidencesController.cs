using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Register_login.Models;

namespace Register_login.Controllers
{
    [Route("api/Residences")]
    [ApiController]
    public class ResidencesController : ControllerBase
    {
        private readonly AuthentificationContext _context;

        public ResidencesController(AuthentificationContext context)
        {
            _context = context;
        }

        // GET: api/Residences
        [HttpGet]
        public IEnumerable<Residence> GetResidences()
        {
            return _context.Residences;
        }

        // GET: api/Residences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var residence = await _context.Residences.FindAsync(id);

            if (residence == null)
            {
                return NotFound();
            }

            return Ok(residence);
        }

        // PUT: api/Residences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidence([FromRoute] int id, [FromBody] Residence residence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residence.Id)
            {
                return BadRequest();
            }

            _context.Entry(residence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidenceExists(id))
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

        // POST: api/Residences
        [HttpPost]
        public async Task<IActionResult> PostResidence([FromBody] Residence residence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Residences.Add(residence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResidence", new { id = residence.Id }, residence);
        }

        // DELETE: api/Residences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var residence = await _context.Residences.FindAsync(id);
            if (residence == null)
            {
                return NotFound();
            }

            _context.Residences.Remove(residence);
            await _context.SaveChangesAsync();

            return Ok(residence);
        }

        private bool ResidenceExists(int id)
        {
            return _context.Residences.Any(e => e.Id == id);
        }
    }
}