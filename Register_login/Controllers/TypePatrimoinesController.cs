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
    [Route("api/TypePatrimoines")]
    [ApiController]
    public class TypePatrimoinesController : ControllerBase
    {
        private readonly AuthentificationContext _context;

        public TypePatrimoinesController(AuthentificationContext context)
        {
            _context = context;
        }

        // GET: api/TypePatrimoines
        [HttpGet]
        public IEnumerable<TypePatrimoine> GetTypePatrimoines()
        {
            return _context.TypePatrimoines;
        }

        // GET: api/TypePatrimoines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypePatrimoine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typePatrimoine = await _context.TypePatrimoines.FindAsync(id);

            if (typePatrimoine == null)
            {
                return NotFound();
            }

            return Ok(typePatrimoine);
        }

        // PUT: api/TypePatrimoines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePatrimoine([FromRoute] int id, [FromBody] TypePatrimoine typePatrimoine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typePatrimoine.Id)
            {
                return BadRequest();
            }

            _context.Entry(typePatrimoine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePatrimoineExists(id))
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

        // POST: api/TypePatrimoines
        [HttpPost]
        public async Task<IActionResult> PostTypePatrimoine([FromBody] TypePatrimoine typePatrimoine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TypePatrimoines.Add(typePatrimoine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePatrimoine", new { id = typePatrimoine.Id }, typePatrimoine);
        }

        // DELETE: api/TypePatrimoines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypePatrimoine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typePatrimoine = await _context.TypePatrimoines.FindAsync(id);
            if (typePatrimoine == null)
            {
                return NotFound();
            }

            _context.TypePatrimoines.Remove(typePatrimoine);
            await _context.SaveChangesAsync();

            return Ok(typePatrimoine);
        }

        private bool TypePatrimoineExists(int id)
        {
            return _context.TypePatrimoines.Any(e => e.Id == id);
        }
    }
}