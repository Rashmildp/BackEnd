using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SugestorBackend.Models;

namespace SugestorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly SuggestorContext _context;

        public HotelsController(SuggestorContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotels>>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotels>> GetHotels(string id)
        {
            var hotels = await _context.Hotels.FindAsync(id);

            if (hotels == null)
            {
                return NotFound();
            }

            return hotels;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(string id, Hotels hotels)
        {
            if (id != hotels.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(hotels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hotels>> PostHotels(Hotels hotels)
        {
            _context.Hotels.Add(hotels);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelsExists(hotels.HotelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHotels", new { id = hotels.HotelId }, hotels);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotels>> DeleteHotels(string id)
        {
            var hotels = await _context.Hotels.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotels);
            await _context.SaveChangesAsync();

            return hotels;
        }

        private bool HotelsExists(string id)
        {
            return _context.Hotels.Any(e => e.HotelId == id);
        }
    }
}
