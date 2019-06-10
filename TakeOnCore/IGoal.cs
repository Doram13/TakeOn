using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeOnCore.Models;

namespace TakeOnCore
{
    public interface IGoal
    {
        Task<ActionResult<IEnumerable<Goal>>> GetGoals();
        Task<ActionResult<Goal>> GetGoal(int id);
        Task PutGoal(int id, Goal goal);
        Task<ActionResult<Goal>> PostGoal(Goal goal);
        Task<ActionResult<Goal>> PostCommitment(Goal goal);
        Task<ActionResult<Goal>> PostQuestion(Goal goal);

        Task<ActionResult<Goal>> DeleteGoal(int id);
        bool GoalExists(int id);

    }
}
