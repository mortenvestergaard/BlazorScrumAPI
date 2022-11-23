using BlazorScrumAPI.Data;
using BlazorScrumAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

		// GET: api/<TaskController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Models.Task>>> GetTask()
		{

			return await _context.Tasks.ToListAsync();
		}

		// GET api/<TaskController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<TaskController>
		[HttpPost]
		public async Task<ActionResult<Models.Task>> Post([FromBody] Models.Task task)
		{
			if (task != null)
			{
				_context.Tasks.Add(task);
				await _context.SaveChangesAsync();
			}
			return Ok(task);
		}

		// PUT api/<TaskController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<TaskController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
