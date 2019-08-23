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
    [Route("api/Patremoines")]
    [ApiController]
    public class PatremoinesController : ControllerBase
    {
        private readonly AuthentificationContext _context;

        public PatremoinesController(AuthentificationContext context)
        {
            _context = context;
        }

        // GET: api/Patremoines
        [HttpGet]
        public IEnumerable<Patremoine> GetPatremoines()
        {
            return _context.Patremoines;
        }

        // GET: api/Patremoines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatremoine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patremoine = await _context.Patremoines.FindAsync(id);

            if (patremoine == null)
            {
                return NotFound();
            }

            return Ok(patremoine);
        }

        // PUT: api/Patremoines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatremoine([FromRoute] int id, [FromBody] Patremoine patremoine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patremoine.Id)
            {
                return BadRequest();
            }

            _context.Entry(patremoine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatremoineExists(id))
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

        // POST: api/Patremoines
        [HttpPost]
        public async Task<IActionResult> PostPatremoine([FromBody] Patremoine patremoine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Patremoines.Add(patremoine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatremoine", new { id = patremoine.Id }, patremoine);
        }

        // DELETE: api/Patremoines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatremoine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patremoine = await _context.Patremoines.FindAsync(id);
            if (patremoine == null)
            {
                return NotFound();
            }

            _context.Patremoines.Remove(patremoine);
            await _context.SaveChangesAsync();

            return Ok(patremoine);
        }

        private bool PatremoineExists(int id)
        {
            return _context.Patremoines.Any(e => e.Id == id);
        }
    }
}