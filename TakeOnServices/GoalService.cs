using Microsoft.EntityFrameworkCore;
using TakeOnCore.Models;
using TakeOnCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeOnFront;
using Microsoft.AspNetCore.Mvc;
using TakeOnFront.Data;
using TakeOnServices;

namespace TakeOnServices
{
    public class GoalService : IGoal
    {

        private readonly ApplicationDbContext _context;

        public GoalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
        {
            return await _context.Goals.ToListAsync();
        }

        public async Task<ActionResult<Goal>> GetGoal(int id)
        {
            return await _context.Goals.FindAsync(id);

        }

        public async Task PutGoal(int id, Goal goal)
        {

            _context.Entry(goal).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbex)
            {
                Console.WriteLine(dbex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update in database: {ex.Message}");
            }
        }

        public async Task<ActionResult<Goal>> PostGoal(Goal goal)
        {
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return goal;
            
        }

        public async Task<ActionResult<Goal>> PostCommitment(Goal goal)
        {
            goal.GoalType = GoalType.Commit;
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return goal;
        }

        public async Task<ActionResult<Goal>> PostQuestion(Goal goal)
        {
            goal.GoalType = GoalType.Question;
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return goal;
        }

        public async Task<ActionResult<Goal>> DeleteGoal(int id)
        {
            Goal goalToDelete = await _context.Goals.FindAsync(id);
            try
            {
                _context.Goals.Remove(goalToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return goalToDelete;
        }
        public bool GoalExists(int id)
        {
            return _context.Goals.Any(e => e.Id == id);
        }
    }
}
