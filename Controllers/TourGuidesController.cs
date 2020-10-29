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
    public class TourGuidesController : ControllerBase
    {
        private readonly SuggestorContext _context;

        public TourGuidesController(SuggestorContext context)
        {
            _context = context;
        }

        // GET: api/TourGuides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourGuide>>> GetTourGuide()
        {
            return await _context.TourGuide.ToListAsync();
        }

        // GET: api/TourGuides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourGuide>> GetTourGuide(string id)
        {
            var tourGuide = await _context.TourGuide.FindAsync(id);

            if (tourGuide == null)
            {
                return NotFound();
            }

            return tourGuide;
        }

        // PUT: api/TourGuides/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourGuide(string id, TourGuide tourGuide)
        {
            if (id != tourGuide.GuideId)
            {
                return BadRequest();
            }

            _context.Entry(tourGuide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourGuideExists(id))
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

        // POST: api/TourGuides
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TourGuide>> PostTourGuide(TourGuide tourGuide)
        {
            _context.TourGuide.Add(tourGuide);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TourGuideExists(tourGuide.GuideId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTourGuide", new { id = tourGuide.GuideId }, tourGuide);
        }

        // DELETE: api/TourGuides/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TourGuide>> DeleteTourGuide(string id)
        {
            var tourGuide = await _context.TourGuide.FindAsync(id);
            if (tourGuide == null)
            {
                return NotFound();
            }

            _context.TourGuide.Remove(tourGuide);
            await _context.SaveChangesAsync();

            return tourGuide;
        }

        private bool TourGuideExists(string id)
        {
            return _context.TourGuide.Any(e => e.GuideId == id);
        }
    }
}
