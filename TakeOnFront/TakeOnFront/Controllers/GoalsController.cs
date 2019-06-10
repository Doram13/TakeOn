using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeOnCore.Models;
using TakeOnFront.Data;
using TakeOnCore;
using TakeOnServices;

namespace TakeOnFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoal GoalService;

        public GoalsController(IGoal goalService)
        {
            GoalService = goalService;
        }

        // GET: api/Goals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
        {
            return await GoalService.GetGoals();
        }

        // GET: api/Goals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> GetGoal(int id)
        {
            var goal = await GoalService.GetGoal(id);

            if (goal == null)
            {
                return NotFound();
            }

            return goal;
        }

        // PUT: api/Goals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, Goal goal)
        {
            if (!GoalExists(id))
            {
                return NotFound();
            }
            if (id != goal.Id)
            {
                return BadRequest();
            }
            await GoalService.PutGoal(id, goal);
            return NoContent();
        }

        // POST: api/Goals
        [HttpPost]
        public async Task<ActionResult<Goal>> PostGoal(Goal goal)
        {
            await GoalService.PostGoal(goal);
            return CreatedAtAction("GetGoal", new { id = goal.Id }, goal);
        }

        // POST: api/Goals/Commitment
        [HttpPost("Commitment")]
        public async Task<ActionResult<Goal>> PostCommitment(Goal goal)
        {
            await GoalService.PostCommitment(goal);
            return CreatedAtAction("GetGoal", new { id = goal.Id , GoalType = GoalType.Commit }, goal);
        }

        // POST: api/Goals/Question
        [HttpPost("Question")]
        public async Task<ActionResult<Goal>> PostQuestion(Goal goal)
        {
            await GoalService.PostQuestion(goal);
            return CreatedAtAction("GetGoal", new { id = goal.Id, GoalType = GoalType.Question }, goal);
        }

        // DELETE: api/Goals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Goal>> DeleteGoal(int id)
        {
            var goal = await GetGoal(id);
            if (goal == null)
            {
                return NotFound();
            }
            await DeleteGoal(id);
            return goal;
        }

        private bool GoalExists(int id)
        {
            return GoalService.GoalExists(id);
        }
    }
}
