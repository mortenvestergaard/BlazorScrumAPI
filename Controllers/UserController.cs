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
using MimeKit;
using MailKit.Net.Smtp;

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

        /// <summary>
        /// Sends an email to the specified email address when a new task is created for the assignee
        /// </summary>
        /// <param name="user"></param>
        [HttpPost("SendEmail")]
        public async Task<ActionResult> SendEmail(User user)
        {

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(user.Username, "mivest@hotmail.com"));
                message.To.Add(new MailboxAddress("Morten Vestergaard", "mbvestergaard@hotmail.com"));
                message.Subject = "New task created";
                message.Body = new TextPart()
                {
                    Text = "New task created on BoardOne for user: " + user
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.office365.com", 587, false);

                    //Hidden for privacy reasons
                    client.Authenticate("EMAIL", "PASSWORD");

                    client.Send(message);
                    client.Disconnect(true);
                }
                    return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            finally { }

        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<DbUser>> CreateUser(DbUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
    }
}
