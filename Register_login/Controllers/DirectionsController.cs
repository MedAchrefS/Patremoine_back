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
    [Route("api/Directions")]
    [ApiController]
    public class DirectionsController : ControllerBase
    {
        private readonly AuthentificationContext _context;

        public DirectionsController(AuthentificationContext context)
        {
            _context = context;
        }

        // GET: api/Directions
        [HttpGet]
        public IEnumerable<Direction> GetDirections()
        {
            return _context.Directions;
        }

        // GET: api/Directions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirection([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var direction = await _context.Directions.FindAsync(id);

            if (direction == null)
            {
                return NotFound();
            }

            return Ok(direction);
        }

        // PUT: api/Directions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirection([FromRoute] int id, [FromBody] Direction direction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != direction.Id)
            {
                return BadRequest();
            }

            _context.Entry(direction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(id))
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

        // POST: api/Directions
        [HttpPost]
        public async Task<IActionResult> PostDirection([FromBody] Direction direction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Directions.Add(direction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirection", new { id = direction.Id }, direction);
        }

        // DELETE: api/Directions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirection([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var direction = await _context.Directions.FindAsync(id);
            if (direction == null)
            {
                return NotFound();
            }

            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();

            return Ok(direction);
        }

        private bool DirectionExists(int id)
        {
            return _context.Directions.Any(e => e.Id == id);
        }
    }
}