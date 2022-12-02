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
using System.Net.Mail;
using System.Net;

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


        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<DbUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<DbUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("SendEmail")]
        public async Task<ActionResult> SendEmail(User user)
        {
            var client = new SmtpClient();

            try
            {
                client.Port = 81;
                client.Host = "";

                NetworkCredential credentials = new NetworkCredential();
                credentials.Password = "";
                credentials.UserName = "";
                client.Credentials = credentials;

                MailAddress sender = new MailAddress(user.Email, user.Username);

                MailAddress receiver = new MailAddress("mort286f@zbc.dk", "Morten2");

                MailMessage msg = new MailMessage(sender, receiver);
                msg.Subject = "BlazorScrumApp New Task";
                msg.Body = "A task was created in the BlazorScrumApp";

                
                client.Send(msg);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            finally { client.Dispose(); }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, DbUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult<DbUser>> CreateUser(DbUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
