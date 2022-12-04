using BlazorScrumAPI.BusinessModels;
using System.ComponentModel.DataAnnotations;

namespace BlazorScrumAPI.Models
{
	public class DbScrumTask
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int BoardID { get; set; }
		public int StateID { get; set; }
		public int AssigneeID { get; set; }
		public int ReporterID { get; set; }

		public DbBoard? Board { get; set; }
		public DbState? State { get; set; }
		public DbUser? Assignee { get; set; }
		public DbUser? Reporter { get; set; }

		public DbScrumTask()
		{

		}

		//Constructor to map the Task business model to the database model
		public DbScrumTask(ScrumTask scrumTask)
		{
			Id = scrumTask.Id;
			Title = scrumTask.Title;
			Description = scrumTask.Description;
			BoardID = scrumTask.BoardID;
			StateID = scrumTask.StateID;
			AssigneeID = scrumTask.AssigneeID;
			ReporterID = scrumTask.ReporterID;
		}
	}
}
