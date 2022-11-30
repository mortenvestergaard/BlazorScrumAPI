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
	}
}
