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
			modelBuilder.Entity<Board>().HasData(
				new Board
				{
					Id = 1,
					Name = "BoardOne",
					
				}
				);

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

			modelBuilder.Entity<Models.Task>().HasData(
				new Models.Task
				{
					Id = 1,
					Title = "Do some code",
					Description = "Do the thing with the code",
					BoardID = 1,
					StateID = 1,
					AssigneeID = 1,
					ReporterID = 2
				},

                new Models.Task
                {
                    Id = 2,
                    Title = "Check some code",
                    Description = "Do the other thing with the code",
                    BoardID = 1,
                    StateID = 2,
                    AssigneeID = 1,
                    ReporterID = 2
                },
                new Models.Task
                {
                    Id = 3,
                    Title = "What now",
                    Description = "I really dont know",
                    BoardID = 1,
                    StateID = 3,
                    AssigneeID = 2,
                    ReporterID = 1
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
