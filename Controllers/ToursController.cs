using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTour.Data;
using WebTour.Models;
using WebTour.Data;
using WebTour.Models;

namespace WebTour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly WebApiTourContext _context;

        public ToursController(WebApiTourContext context)
        {
            _context = context;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            if (_context.Tours == null)
            {
                return NotFound();
            }
            return await _context.Tours.ToListAsync();
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            if (_context.Tours == null)
            {
                return NotFound();
            }
            var tour = await _context.Tours.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Tour location)
        {
            if (id != location.IdTour)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostLocation(Tour location)
        {
            if (_context.Tours == null)
            {
                return Problem("Entity set 'WebApiTourContext.Locations'  is null.");
            }
            _context.Tours.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.IdTour }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (_context.Tours == null)
            {
                return NotFound();
            }
            var location = await _context.Tours.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool TourExists(int id)
        {
            return (_context.Tours?.Any(e => e.IdTour == id)).GetValueOrDefault();
        }
    }
}
