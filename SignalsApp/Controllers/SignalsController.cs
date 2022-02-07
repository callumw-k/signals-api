#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalsApp.Models;

namespace SignalsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalsController : ControllerBase
    {
        private readonly SignalsDbContext _context;

        public SignalsController(SignalsDbContext context)
        {
            _context = context;
        }

        // GET: api/Signals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Signal>>> GetSignals()
        {
            return await _context.Signals.ToListAsync();
        }

        // GET: api/Signals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Signal>> GetSignal(int id)
        {
            var signal = await _context.Signals.FindAsync(id);

            if (signal == null)
            {
                return NotFound();
            }

            return signal;
        }

        // PUT: api/Signals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignal(int id, Signal signal)
        {
            if (id != signal.Id)
            {
                return BadRequest();
            }

            _context.Entry(signal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignalExists(id))
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

        // POST: api/Signals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Signal>> PostSignal(Signal signal)
        {
            _context.Signals.Add(signal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignal", new { id = signal.Id }, signal);
        }

        // DELETE: api/Signals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignal(int id)
        {
            var signal = await _context.Signals.FindAsync(id);
            if (signal == null)
            {
                return NotFound();
            }

            _context.Signals.Remove(signal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SignalExists(int id)
        {
            return _context.Signals.Any(e => e.Id == id);
        }
    }
}
