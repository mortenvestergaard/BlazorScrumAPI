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
    public class StateController : ControllerBase
    {
        private readonly ScrumBoardContext _context;

        public StateController(ScrumBoardContext context)
        {
            _context = context;
        }


        [HttpGet("GetStates")]
        public async Task<ActionResult<IEnumerable<DbState>>> GetStates()
        {
            var response = await _context.States.ToListAsync();
            return response;
        }

        // GET: api/State/5
        [HttpGet("GetState")]
        public async Task<ActionResult<DbState>> GetState(int id)
        {
            var state = await _context.States.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }


        [HttpPost("CreateState")]
        public async Task<ActionResult<DbState>> PostState(State state)
        {
            DbState newState = new DbState()
            {
                Id= state.Id,
                Name= state.Name,
                
            };
            _context.States.Add(newState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetState", new { id = newState.Id }, newState);
        }

        // DELETE: api/State/5
        [HttpDelete("DeleteState")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(int id)
        {
            return _context.States.Any(e => e.Id == id);
        }
    }
}
