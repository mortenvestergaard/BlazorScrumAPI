using BlazorScrumAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorScrumAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BoardController : ControllerBase
	{
		private readonly ScrumBoardContext _context;

		public BoardController(ScrumBoardContext context)
		{
			_context = context;
		}


		// GET: api/<BoardController>
		[HttpGet("GetBoards")]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<BoardController>/5
		[HttpGet("GetBoard")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<BoardController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<BoardController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<BoardController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
