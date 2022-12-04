using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorScrumAPI.Data;
using BlazorScrumAPI.Models;

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

        [HttpGet("ClearBoard")]
        public async Task ClearBoard()
        {
            _context.Tasks.RemoveRange(_context.Tasks);
            _context.States.RemoveRange(_context.States);
            await _context.SaveChangesAsync();
        }
    }
}
