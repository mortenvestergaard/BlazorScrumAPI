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
            var response = await _context.Tasks.Include(e => e.State).Include(x => x.Board).Include(y => y.Assignee).Include(u => u.Reporter).ToListAsync();
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

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(ScrumTask task)
        {


            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult<DbScrumTask>> CreateTask(ScrumTask task)
        {
            DbScrumTask newTask = new DbScrumTask(task);
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
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
