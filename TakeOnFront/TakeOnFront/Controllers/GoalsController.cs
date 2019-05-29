using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeOnCore.Models;
using TakeOnFront.Data;

namespace TakeOnFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyRoutinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DailyRoutinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyRoutines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetDailyRoutines()
        {
            return await _context.Goals.ToListAsync();
        }

        // GET: api/DailyRoutines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> GetDailyRoutine(int id)
        {
            var dailyRoutine = await _context.Goals.FindAsync(id);

            if (dailyRoutine == null)
            {
                return NotFound();
            }

            return dailyRoutine;
        }

        // PUT: api/DailyRoutines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyRoutine(int id, Goal dailyRoutine)
        {
            if (id != dailyRoutine.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyRoutine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyRoutineExists(id))
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

        // POST: api/DailyRoutines
        [HttpPost]
        public async Task<ActionResult<Goal>> PostDailyRoutine(Goal dailyRoutine)
        {
            _context.Goals.Add(dailyRoutine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyRoutine", new { id = dailyRoutine.Id }, dailyRoutine);
        }

        // DELETE: api/DailyRoutines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Goal>> DeleteDailyRoutine(int id)
        {
            var dailyRoutine = await _context.Goals.FindAsync(id);
            if (dailyRoutine == null)
            {
                return NotFound();
            }

            _context.Goals.Remove(dailyRoutine);
            await _context.SaveChangesAsync();

            return dailyRoutine;
        }

        private bool DailyRoutineExists(int id)
        {
            return _context.Goals.Any(e => e.Id == id);
        }
    }
}
