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
    public class TransportProvidersController : ControllerBase
    {
        private readonly SuggestorContext _context;

        public TransportProvidersController(SuggestorContext context)
        {
            _context = context;
        }

        // GET: api/TransportProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportProvider>>> GetTransportProvider()
        {
            return await _context.TransportProvider.ToListAsync();
        }

        // GET: api/TransportProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportProvider>> GetTransportProvider(string id)
        {
            var transportProvider = await _context.TransportProvider.FindAsync(id);

            if (transportProvider == null)
            {
                return NotFound();
            }

            return transportProvider;
        }

        // PUT: api/TransportProviders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportProvider(string id, TransportProvider transportProvider)
        {
            if (id != transportProvider.Tpid)
            {
                return BadRequest();
            }

            _context.Entry(transportProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportProviderExists(id))
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

        // POST: api/TransportProviders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportProvider>> PostTransportProvider(TransportProvider transportProvider)
        {
            _context.TransportProvider.Add(transportProvider);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransportProviderExists(transportProvider.Tpid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransportProvider", new { id = transportProvider.Tpid }, transportProvider);
        }

        // DELETE: api/TransportProviders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportProvider>> DeleteTransportProvider(string id)
        {
            var transportProvider = await _context.TransportProvider.FindAsync(id);
            if (transportProvider == null)
            {
                return NotFound();
            }

            _context.TransportProvider.Remove(transportProvider);
            await _context.SaveChangesAsync();

            return transportProvider;
        }

        private bool TransportProviderExists(string id)
        {
            return _context.TransportProvider.Any(e => e.Tpid == id);
        }
    }
}
