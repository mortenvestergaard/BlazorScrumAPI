using BlazorScrumAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorScrumAPI.Data
{
	public class ScrumBoardContext : DbContext
	{
		public ScrumBoardContext(DbContextOptions<ScrumBoardContext> options) :base(options)
		{
			//DbContext.Database.GetService<IRelationalDatabaseCreator>().Exists();
		}

		public DbSet<Board> Boards { get; set; }
		public DbSet<Models.Task> Tasks { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<State> States { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Username = "Alex Lackovic"
				},
				new User
				{
					Id = 2,
					Username = "Benjamin Roesdal"
				}
				);
		}
	}
}
