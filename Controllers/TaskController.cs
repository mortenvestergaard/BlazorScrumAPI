using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorScrumAPI.Data;
using BlazorScrumAPI.Models;
using BlazorScrumAPI.BusinessModels;

namespace BlazorScrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ScrumBoardContext _context;

        public TaskController(ScrumBoardContext context)
        {
            _context = context;
        }


        [HttpGet("GetTasks")]
        public async Task<ActionResult<IEnumerable<Models.DbScrumTask>>> GetTasks()
        {
            var response = await _context.Tasks.Include(e => e.State).ToListAsync();
            return response;
        }


        [HttpGet("GetTask")]
        public async Task<ActionResult<DbScrumTask>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }


        [HttpPost("CreateTask")]
        public async Task<ActionResult<DbScrumTask>> CreateTask(ScrumTask task)
        {
            DbScrumTask newTask = new DbScrumTask()
            {
                Id = task.Id,
                Title= task.Title,
                Description= task.Description,
                StateID= task.StateID,
                BoardID= task.BoardID,
                AssigneeID= task.AssigneeID,
                ReporterID= task.ReporterID,
                Assignee = task.Assignee,
                Reporter = task.Reporter,
                Board = task.Board,
                State = task.State

            };
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = newTask.Id }, newTask);
        }


        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
