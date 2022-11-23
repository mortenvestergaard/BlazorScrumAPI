using BlazorScrumAPI.Data;
using BlazorScrumAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorScrumAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ScrumBoardContext _context;
		public UserController(ScrumBoardContext context)
		{
			_context = context;
		}

		// GET: api/<UserController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<UserController>
		[HttpPost]
		public async Task<ActionResult<Models.User>> Post([FromBody] User user)
		{
			if (user != null)
			{
				_context.Users.Add(user);
				await _context.SaveChangesAsync();
			}
			return Ok(user);
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
