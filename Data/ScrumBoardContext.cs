using BlazorScrumAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorScrumAPI.Data
{
	public class ScrumBoardContext : DbContext
	{
		public ScrumBoardContext(DbContextOptions<ScrumBoardContext> options) :base(options)
		{

		}

		public DbSet<Board> Boards { get; set; }
		public DbSet<Models.Task> Tasks { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<State> States { get; set; }

	}
}
