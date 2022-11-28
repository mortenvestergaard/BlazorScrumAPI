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

			modelBuilder.Entity<State>().HasData(
				new State
				{
					Id = 1,
					Name = "To Do"
				},
				new State
				{
					Id = 2,
					Name = "In Progress"
				},
				new State
				{
					Id = 3,
					Name = "Done"
				}
				);

			modelBuilder.Entity<Models.Task>()
				.HasOne(x => x.Assignee)
				.WithMany(x => x.AssigneeTasks)
				.HasForeignKey(x => x.AssigneeID)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Models.Task>()
				.HasOne(x => x.Reporter)
				.WithMany(x => x.ReporterTasks)
				.HasForeignKey(x => x.ReporterID)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
