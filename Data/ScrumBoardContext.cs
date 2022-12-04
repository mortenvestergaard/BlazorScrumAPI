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

		public DbSet<DbBoard> Boards { get; set; }
		public DbSet<DbScrumTask> Tasks { get; set; }
		public DbSet<DbUser> Users { get; set; }
		public DbSet<DbState> States { get; set; }

		//Data seeding
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DbBoard>().HasData(
				new DbBoard
				{
					Id = 1,
					Name = "BoardOne",
					
				}
				);

			modelBuilder.Entity<DbUser>().HasData(
				new DbUser
				{
					Id = 1,
					Username = "Morten Vestergaard",
					Email = "mivest@hotmail.com"
				},
				new DbUser
				{
					Id = 2,
					Username = "Benjamin Roesdal",
					Email = "mivest@hotmail.com"
				}
				);

			modelBuilder.Entity<DbState>().HasData(
				new DbState
				{
					Id = 1,
					Name = "To Do"
				},
				new DbState
				{
					Id = 2,
					Name = "In Progress"
				},
				new DbState
				{
					Id = 3,
					Name = "Done"
				}
				);

			modelBuilder.Entity<DbScrumTask>().HasData(
				new DbScrumTask
				{
					Id = 1,
					Title = "Do some code",
					Description = "Do the thing with the code",
					BoardID = 1,
					StateID = 1,
					AssigneeID = 1,
					ReporterID = 2
				},

                new DbScrumTask
                {
                    Id = 2,
                    Title = "Check some code",
                    Description = "Do the other thing with the code",
                    BoardID = 1,
                    StateID = 2,
                    AssigneeID = 1,
                    ReporterID = 2
                },
                new DbScrumTask
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

			modelBuilder.Entity<DbScrumTask>()
				.HasOne(x => x.Assignee)
				.WithMany(x => x.AssigneeTasks)
				.HasForeignKey(x => x.AssigneeID)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<DbScrumTask>()
				.HasOne(x => x.Reporter)
				.WithMany(x => x.ReporterTasks)
				.HasForeignKey(x => x.ReporterID)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
